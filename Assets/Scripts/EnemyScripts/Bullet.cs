using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifetime = 3f;

    private Vector2 direction = Vector2.zero;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
    public void Init(Vector2 dir)
    {
        Vector2 direction = dir.normalized;
        rb.linearVelocity = direction * speed;

        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If you later tag the player as "Player"
        if (other.CompareTag("Player"))
        {
            // Apply damage here if your player has health script
            // other.GetComponent<PlayerHealth>()?.TakeDamage(1);

            Destroy(gameObject);
        }

        // Add logic for hitting walls or environment
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}