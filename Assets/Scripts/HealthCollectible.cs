using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int givenHealth;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        // Check if the player exists and if its health isn't maxed
        if (player != null && !player.IsHealthMaxed())
        {
            player.ChangeHealth(givenHealth);
            Destroy(gameObject);
        }
    }
}
