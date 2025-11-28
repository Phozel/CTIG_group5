using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject player;
    public float movement_speed = 10;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.up * movement_speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.down * movement_speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * movement_speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * movement_speed * Time.deltaTime);
        }
    }
}
