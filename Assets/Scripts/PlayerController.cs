using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Unity's variable
    public InputAction moveAction;
    public InputAction talkAction;
    public InputAction fireAction;
    private Rigidbody2D rb;
    public Vector2 move;

    // Speed and maxHealth of the player
    public float speed = 5.0F;
    public int maxHealth = 5;

    // Variables related to temporary invincibility
    public float timeInvincible = 1.5F;
    private bool isInvincible;
    private float damageCooldown;

    private int currentHealth;

    // Animation's variables
    private Animator animator;
    Vector2 moveDirection = new Vector2(1, 0);

    // Projectiles
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    protected void Start()
    {
        talkAction.Enable();
        fireAction.Enable();
        moveAction.Enable();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    protected void Update()
    {
        move = moveAction.ReadValue<Vector2>();
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }

        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Look Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }

        if (fireAction.WasPerformedThisFrame())
        {
            Launch();
        }

        if (talkAction.WasPerformedThisFrame())
        {
            FindFriend();
        }
    }

    // Move the player based on the inputs and speed
    protected void FixedUpdate()
    {
        Vector2 position = (Vector2)rb.position + move * speed * Time.deltaTime;
        rb.MovePosition(position);
    }

    // Change the player's health
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            animator.SetTrigger("Hit");
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
        }
        currentHealth = Math.Clamp(currentHealth + amount, 0, maxHealth);
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth);
    }

    // Return 'true' if the player's current health is at max, otherwise 'false' 
    public bool IsHealthMaxed()
    {
        return currentHealth == maxHealth;
    }

    // Launches a projectiles
    public void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectiles projectile = projectileObject.GetComponent<Projectiles>();
        projectile.Launch(moveDirection, 300);
        animator.SetTrigger("Launch");
    }

    public void FindFriend()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, moveDirection, 1.5f, LayerMask.GetMask("NPC"));

        if (hit.collider != null)
        {
            NPCController npc = hit.collider.GetComponent<NPCController>();
            if (npc != null)
            {
                UIHandler.instance.DisplayDialogue();
            }
        }
    }
}
