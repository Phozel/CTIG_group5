using Unity.Mathematics.Geometry;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float rangeY = 1f;
    public float rangeX = 1f;

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
        float yOffset = Mathf.Sin(Time.time * speed) * rangeY;
        float xOffset = Mathf.Sin(Time.time * speed) * rangeX;
        transform.position = new Vector2(startPos.x + xOffset, startPos.y + yOffset);

    }
}
