using UnityEngine;

public class Projectiles : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        DestroyAfterDelay();
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

    void DestroyAfterDelay()
    {
        Destroy(gameObject, 5f);
    }
}