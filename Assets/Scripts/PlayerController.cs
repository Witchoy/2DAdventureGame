using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Unity's variable
    public InputAction moveAction;
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

    // Start is called before the first frame update
    protected void Start()
    {
        moveAction.Enable();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    protected void Update()
    {
        move = moveAction.ReadValue<Vector2>();

        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
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
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
        }
        currentHealth = Math.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    // Return 'true' if the player's current health is at max, otherwise 'false' 
    public bool IsHealthMaxed()
    {
        return currentHealth == maxHealth;
    }
}
