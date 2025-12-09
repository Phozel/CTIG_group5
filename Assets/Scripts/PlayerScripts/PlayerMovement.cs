using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D body;
    private BoxCollider2D collider;
    public float movement_speed = 5;
    public float jump_force = 10;

    private float startY;
    bool isGrounded;
    bool canJump;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            if (!isGrounded && body.linearVelocityY != 0)
            {
                body.linearVelocityX = 0;
            }
            player.transform.Translate(Vector2.left * movement_speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            if(!isGrounded && body.linearVelocityY != 0) { 
                body.linearVelocityX = 0;
            }
            player.transform.Translate(Vector2.right * movement_speed * Time.deltaTime);
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && canJump) 
        {   
            if (body.linearVelocityY <= 0)
                body.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag.Equals("Teleporter"))
        {
            Debug.Log("Teleporter touched");
            if (collision.gameObject.name == "LeftTeleport")
            {
                Debug.Log("Left touched");
                player.transform.position = new Vector2(5.5f, player.transform.position.y);
            }
            else if (collision.gameObject.name == "RightTeleport")
            {
                Debug.Log("Right touched");
                player.transform.position = new Vector2(-5.5f, player.transform.position.y);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        if (body.totalForce.y == 0)
        {
            canJump = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        canJump = false;
    }
    
}
