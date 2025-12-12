// -----------------------------
// File: AudioManager.cs
//
// Co-created using ChatGPT
// -----------------------------
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Range(0f, 1f)] public float masterVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;
    public bool muted = false;

    [Header("Sound Library")]
    public Sound[] sounds;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource sfx3DSource;


    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }


    }

    // Play 2D sound by name
    public void Play(string soundName)
    {
        if (!muted)
        {
            Debug.Log("Playing sound: " + soundName);

            Sound s = FindSound(soundName);
            if (s == null) return;

            sfxSource.pitch = s.pitch;
            sfxSource.volume = s.volume * masterVolume;
            sfxSource.loop = s.loop;
            sfxSource.spatialBlend = 0f;
            Debug.Log("Volume: " + s.volume);
            if (s.loop)
                sfxSource.clip = s.clip;

            if (s.loop && !sfxSource.isPlaying)
                sfxSource.Play();
            else
                sfxSource.PlayOneShot(s.clip);
        }
    }

    // Play 3D sound at position
    public void PlayAtPosition(string soundName, Vector3 pos)
    {
        if (!muted)
        {
            Sound s = FindSound(soundName);
            if (s == null) return;

            AudioSource.PlayClipAtPoint(s.clip, pos, s.volume * masterVolume);
        }
    }

    // Stop looping sound
    public void Stop(string soundName)
    {
        Sound s = FindSound(soundName);
        if (s == null) return;

        // if (sfxSource.clip == s.clip)
        sfxSource.Stop();
    }

    private Sound FindSound(string name)
    {
        foreach (var s in sounds)
        {
            Debug.Log("Checking sound: " + s.soundName);
            if (s.soundName == name)
                return s;
        }
        Debug.LogWarning("Sound not found: " + name);
        return null;
    }

    public void SetMasterVolume(float value)
    {
        masterVolume = value;
        ApplyVolumes();
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
        ApplyVolumes();
    }

    public void mute()
    {
        muted = !muted;

    }

    private void ApplyVolumes()
    {
        float finalSFX = masterVolume * sfxVolume;
        if (sfxSource)
            sfxSource.volume = finalSFX;
        if (sfx3DSource)
            sfx3DSource.volume = finalSFX;

    }
}
