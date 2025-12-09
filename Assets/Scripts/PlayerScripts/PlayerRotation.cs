using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float speed = 4f;
    private Quaternion originalRotation;
    private Transform currentPlatform = null;

    void Start()
    {
        originalRotation = this.transform.rotation;

    }

    void Update()
    {
        if (currentPlatform != null)
        {
            float z = currentPlatform.eulerAngles.z;
            transform.rotation = Quaternion.Euler(0, 0, z);  
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("RotatedPlatform"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    currentPlatform = collision.collider.transform.root;
                    return;
                }
            }   
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("RotatedPlatform"))
        {
            currentPlatform = null;
        }
    }
}
