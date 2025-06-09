using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Projectile collision with " + collision.gameObject);
        Destroy(gameObject);
    }
}
