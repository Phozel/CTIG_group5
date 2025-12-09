using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public bool hasPowerUp;
    public float powerUpDuration = 25f;
    public float jumpForceMultiplier = 25f;
    private Rigidbody2D playerRb;
    private PlayerMovement playerMovement;
    private GameObject powerUp;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (hasPowerUp)
        {
            PowerUpJump();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("PowerUp"))
        {
            powerUp = other.gameObject;
            CollectPowerUp();
        }
    }

    

    public void PowerUpJump()
    {
        if (!hasPowerUp) 
        {
            return;
        }
        if (playerRb != null)
        {
          
                playerRb.AddForce(Vector2.up * jumpForceMultiplier, ForceMode2D.Impulse);
            hasPowerUp = false;
            return;
        }
    }
    public void CollectPowerUp()
    {
        if(hasPowerUp)
        {
            return;
        }

        hasPowerUp = true;
        PowerUpJump();
        if(powerUp != null)
        {
            Destroy(powerUp.gameObject);        
        }
    }
}