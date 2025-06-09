using System;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    // Public variables
    public float speed;
    public bool vertical;
    public float changeTime = 3.0F;
    public int damage = 1;

    // Private variables
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private float timer;
    private int direction = 1;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
    }

    // Update is called every frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
            animator.SetFloat("MoveY", direction);
            animator.SetFloat("MoveX", 0);
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
            animator.SetFloat("MoveY", 0);
            animator.SetFloat("MoveX", direction);
        }
        rigidbody2d.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log("Collision entenred !");
            player.ChangeHealth(-damage);
        }
        else
        {
            Debug.Log("Player is null ! " + collision.ToString() );
        }
    }
}