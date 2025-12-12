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

        if (dist <= detectRange && timer >= shootCooldown)
        {
            ShootBullet();
            AudioManager.Instance.Play("EnemyShoot");
            timer = 0f;
        }
    }

    void ShootBullet()
    {
        Vector2 direction = (player.position - bulletSpawnPoint.position).normalized;

        GameObject bulletObj = Instantiate(Bullet, bulletSpawnPoint.position, Quaternion.identity);
       
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.Init(direction); 

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
bulletObj.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}