using UnityEngine;

public class Projectiles : MonoBehaviour
{
    Rigidbody2D rb;

    // Awake is called when the Projectile GameObject is instantiated
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Kill();
        }

        Destroy(gameObject);
    }

}