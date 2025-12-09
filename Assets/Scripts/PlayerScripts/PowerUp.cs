using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public bool hasPowerUp;
    public float jumpForceMultiplier = 25f;
    private Rigidbody2D playerRb;
    private PlayerMovement playerMovement;
    private GameObject powerUp;
    public GameObject powerUpEquippedText;
    public GameObject powerUpNoneText;



    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        OnGUI();
        if (hasPowerUp && Input.GetKeyDown(KeyCode.P))
        {
            PowerUpJump();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            powerUp = other.gameObject;
            CollectPowerUp();
        }
    }

    

    public void PowerUpJump()
    {
        if (playerRb != null)
        {
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x,jumpForceMultiplier);
            
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
        if(powerUp != null)
        {
            Destroy(powerUp.gameObject);        
        }
    }
    private void OnGUI()
    {
        if (hasPowerUp)
        {
            powerUpEquippedText.SetActive(true);
            powerUpNoneText.SetActive(false);
        }
        else
        {
            powerUpEquippedText.SetActive(false);
            powerUpNoneText.SetActive(true);
        }
    }
}