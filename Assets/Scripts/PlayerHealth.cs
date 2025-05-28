using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public GameObject player;
    public HealthBar healthBar;
    public Animator animator;
    public Rigidbody2D rb;
    public AudioSource hurtSound;

    public GameObject gameOverPanel;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(100);
            hurtSound.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            TakeDamage(10);
            hurtSound.Play();
        }
        
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyShot"))
        {
            TakeDamage(20);
            hurtSound.Play();
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            animator.SetBool("Alive", false);
            GetComponent<PlayerMouvement>().enabled = false;

            if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}