using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifetime = 3f;

    private Vector2 direction;

    void Start()
    {
        Destroy(gameObject, lifetime); // auto-destroy after some time
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
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