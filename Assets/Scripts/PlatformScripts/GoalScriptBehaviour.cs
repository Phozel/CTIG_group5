using System.Dynamic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

public class GoalScript : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float clappingSoundTime = 5.0f;
    [SerializeField] private float totalCountdown = 7.0f; // 5s clapping + 2s wait

    private LevelLoader _loader;

    private bool goalReached = false;

    // Variables
    void Awake()
    {
        // Attempt to find LevelLoader if not assigned
        _loader = Resources.FindObjectsOfTypeAll<GameObject>()
                          .FirstOrDefault(go => go.name == "LevelLoader").GetComponent<LevelLoader>();

        if (_loader != null)
        {
            UnityEngine.Debug.Log("Get to main menu");
        }
        else
        {
            UnityEngine.Debug.LogError("LevelLoader not found in scene!");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (goalReached) return; // prevent multiple triggers

        if (collision.gameObject.CompareTag("Player"))
        {
            goalReached = true;
            //HandleGoalReached();
        }

        // play clapping sound for 5 seconds
        OnGoalReached(); // trigger successive events
    }

    private void OnGoalReached()
    {
        // for when the goal is reached
        // maybe include some internal timer for the total of 7 seconds? 

        FreezePlayerMovement();
        FreezeTimer(); // freeze in-game timer

        // Play clapping sound
        AudioManager.Instance.Play("Victory");

        // Stop clapping after 5 seconds
        UnityEngine.Debug.Log("Scheduling stop of clapping sound in " + clappingSoundTime + " seconds.");
        Invoke(nameof(StopClappingSound), clappingSoundTime);

        _loader.ReturnToMainMenuDelay(totalCountdown);
    }

    private void StopClappingSound()
    {
        UnityEngine.Debug.Log("Stopping clapping sound");
        AudioManager.Instance.Stop("Victory");
    }

    private void FreezePlayerMovement()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Freeze Rigidbody
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.bodyType = RigidbodyType2D.Static;
            }

            // Disable movement
            PlayerMovement movement = player.GetComponent<PlayerMovement>();
            if (movement != null)
            {
                movement.enabled = false;
            }
        }
    }

    private void UnfreezePlayerMovement()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Unfreeze Rigidbody
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }

            // Enable movement
            PlayerMovement movement = player.GetComponent<PlayerMovement>();
            if (movement != null)
            {
                movement.enabled = true;
            }
        }
    }

    private void FreezeTimer()
    {
        InLevelUI hud = FindObjectOfType<InLevelUI>();
        if (hud != null)
        {
            hud.enabled = false;
        }
    }

    private void StartTimerCountdown()
    {
        // start a countdown timer for 7 seconds
    }

    // Update is called once per frame
    void Update()
    {
    }
}
