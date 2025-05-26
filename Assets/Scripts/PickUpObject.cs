using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public AudioSource pickUpSound;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pickUpSound.Play();
            if (playerHealth.currentHealth >= 80)
            {
                playerHealth.currentHealth = 100;
                playerHealth.healthBar.SetHealth(playerHealth.currentHealth);
                Destroy(gameObject, 0.6f);
                return;
            }
            playerHealth.currentHealth += 20;
            playerHealth.healthBar.SetHealth(playerHealth.currentHealth);
            Destroy(gameObject, 0.6f);
        }
    }
}
