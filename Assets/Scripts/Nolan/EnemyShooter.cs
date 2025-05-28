using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public Animator animator;

    public Transform player;  
    public float shootingRange = 10f; 

    private float timer;
    private bool isDead = false;

    void Start()
    {
        if (player == null)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isDead) return;

        if (player == null) return;

        timer += Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (timer >= fireRate && distanceToPlayer <= shootingRange)
        {
            Shoot();
            timer = 0f;
        }

    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.CompareTag("Shot") && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetTrigger("Dead"); 
        GetComponent<Collider2D>().enabled = false; 
        this.enabled = false; 
        Destroy(gameObject, 1f); 
    }
}
