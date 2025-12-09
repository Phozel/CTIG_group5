using UnityEngine;

public class ParallaxHorizontalOnly : MonoBehaviour
{
    [Range(0f, 1f)]

    // Low values = makes object appear far away
    public float parallaxFactor = 0.2f;

    private Transform camera;
    private float lastCameraX;

    void Start()
    {
        camera = Camera.main.transform;
        lastCameraX = camera.position.x;
    }

    void LateUpdate()
    {
        float deltaX = camera.position.x - lastCameraX;
        transform.position += new Vector3(deltaX * parallaxFactor, 0, 0);
        lastCameraX = camera.position.x;
    }
}
