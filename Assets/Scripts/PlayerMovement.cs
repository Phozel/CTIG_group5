using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D Rigidbody;

    public float movement_speed = 10;
    public float jump_velocity = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get rigidbody component from player
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Handle jumping
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveHorizontal * movement_speed * Time.deltaTime, 0, 0);
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.up * movement_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.down * movement_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * movement_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * movement_speed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.linearVelocity = Vector2.up * jump_velocity;
        }

    }
}
