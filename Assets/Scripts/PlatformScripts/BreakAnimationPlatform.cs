using UnityEngine;

public class BreakAnimationPlatform : MonoBehaviour
{
    //Fade out parameters
    public float fadeDuration = 2.5f;
    private SpriteRenderer sprite;


    //Shaking parameters
    public float intensity = 0.2f;
    public float speed = 2f;           
    private bool isShaking = false;

    private Vector2 originalPos;
    void Start()
    {
       originalPos = transform.localPosition;
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isShaking) return;

        float x = Mathf.PerlinNoise(Time.time * speed, 0f) * intensity;
        float y = Mathf.PerlinNoise(0f, Time.time * speed) * intensity;

        transform.localPosition = originalPos + new Vector2(x, y);
    }

    public void StartShake()
    {
        if (!isShaking)
        {
            isShaking = true;
        }
    }


 public void StartFade()
    {
        StartCoroutine(FadeOut());
    }

    private System.Collections.IEnumerator FadeOut()
    {
        float time = 0f;
        Color startColor = sprite.color;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;
            sprite.color = new Color(startColor.r, startColor.g, startColor.b, 1 - t);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
