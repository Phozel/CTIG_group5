using UnityEngine;
using System.Linq;

public class PowerUp : MonoBehaviour
{

    public bool hasPowerUp;
    public float jumpForceMultiplier = 25f;
    private Rigidbody2D playerRb;
    private PlayerMovement playerMovement;
    private GameObject powerUp;

    private GameObject ItemFrame;
    private GameObject ItemRocket;


    void Awake()
    {
        ItemFrame = Resources.FindObjectsOfTypeAll<GameObject>()
                          .FirstOrDefault(go => go.name == "ImageItemFrame");
        ItemRocket = Resources.FindObjectsOfTypeAll<GameObject>()
                          .FirstOrDefault(go => go.name == "ImageItemOverlay");
    }


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
            ItemRocket.SetActive(true);
        }
        else
        {
            ItemRocket.SetActive(false);
        }
    }
}