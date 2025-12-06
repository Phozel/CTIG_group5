using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bulletSpawnPoint;
    public float shootCooldown = 1.5f;
    public float detectRange = 5f;

    private float timer = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= detectionRange && timer >= shootCooldown)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}