
// -----------------------------
// File: AudioEventTrigger.cs
// Optional helper script for easily triggering sounds from events.
//
// Generated using ChatGPT
// -----------------------------
using UnityEngine;

public class AudioEventTrigger : MonoBehaviour
{
    public void PlaySound(string soundName)
    {
        AudioManager.Instance.Play(soundName);
    }

    public void PlaySoundAtPosition(string soundName)
    {
        AudioManager.Instance.PlayAtPosition(soundName, transform.position);
    }
}
