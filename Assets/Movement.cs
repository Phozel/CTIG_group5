using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float range = 1f;
    public float speed = 2f;

    private Vector2 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yOffset = Math.Sin(Time.time * speed) * range;
        transform.position = new Vector2(transform.position.x - moveSpeed, startPos.y + yOffset);
    }
}
