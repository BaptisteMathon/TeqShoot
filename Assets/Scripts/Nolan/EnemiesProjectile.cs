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
}
