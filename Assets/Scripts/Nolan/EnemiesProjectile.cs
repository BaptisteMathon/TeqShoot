using UnityEngine;

public class EnemiesProjectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 1.5f;

    void Start()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            playerHealth.currentHealth -= 20;
            playerHealth.healthBar.SetHealth(playerHealth.currentHealth);

            if (playerHealth.currentHealth <= 0)
            {
                playerHealth.animator.SetBool("Alive", false);
                playerHealth.GetComponent<PlayerMouvement>().enabled = false;
                playerHealth.gameOverPanel.SetActive(true);
                playerHealth.gameObject.SetActive(false);
            }
            
            Destroy(gameObject);
        }
    }
}
