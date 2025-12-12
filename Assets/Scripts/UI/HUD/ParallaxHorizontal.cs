using UnityEngine;

/*
 Co-created with ChatGPT
 */
public class ParallaxHorizontalOnly : MonoBehaviour
{
    [Range(0f, 0.3f)]
    // Lower = farther away, higher = closer
    public float parallaxFactor = 0.2f;
    public Transform player;

    private float startX; // initial background position
    private float playerStartX; // initial player position

    void Start()
    {
        startX = transform.position.x;

        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }

        if (player != null)
            playerStartX = player.position.x;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // How far player moves in X from starting position
        float playerDeltaX = player.position.x - playerStartX;

        // Background moves less than player
        float newX = startX + (playerDeltaX * parallaxFactor);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}