using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer graphics;
    public Animator animator;

    private Transform target;
    private int destPoint = 0;
    private bool isDead = false;

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        if (isDead) return;

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Le joueur a été touché par un ennemi !");
        }

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
        Destroy(gameObject, 1.0f); 
    }
}

