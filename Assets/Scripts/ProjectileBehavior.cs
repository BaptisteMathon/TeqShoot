using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    public float speed = 4.5f;

    public AudioSource projectileSound;
    public GameObject player;
    public GameObject explosionPrefab;
    public Vector2 direction = Vector2.right;
    SpriteRenderer spriteRendererPlayer;

    void Start()
    {
        projectileSound.Play();
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRendererPlayer = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // if (spriteRendererPlayer.flipX)
        // {
        //     transform.position += -transform.right * Time.deltaTime * speed;
        // }
        // else
        // {
        //     transform.position += transform.right * Time.deltaTime * speed;
        // }
        transform.position += (Vector3)direction * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyShot"))
        {
            if (explosionPrefab != null)
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            
            Destroy(gameObject); 
            Destroy(collision.gameObject);
        }
        else
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
