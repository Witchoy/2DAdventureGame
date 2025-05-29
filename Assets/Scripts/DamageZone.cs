using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int takenHealth;

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        // Check if the player exists and if its health isn't maxed
        if (player != null)
        {
            player.ChangeHealth(-takenHealth);
        }
    }
}
