// -----------------------------
// File: MusicManager.cs
//
// Generated using ChatGPT
// -----------------------------
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;


    [Header("Music Settings")]
    public AudioSource musicSource;
    public AudioClip[] musicTracks;
    public float masterVolume = 1f;
    public float musicVolume = 1f;


    private int currentTrackIndex = 0;


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
        }
    }


    private void Start()
    {
        if (musicTracks.Length > 0)
        {
            PlayMusic(currentTrackIndex);
        }
    }


    public void PlayMusic(int index)
    {
        if (index < 0 || index >= musicTracks.Length)
        {
            Debug.LogWarning("Music index out of range");
            return;
        }


        currentTrackIndex = index;
        musicSource.clip = musicTracks[index];
        musicSource.volume = musicVolume;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        ApplyVolume();
    }

    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        ApplyVolume();
    }

    private void ApplyVolume()
    {
        musicSource.volume = masterVolume * musicVolume;
    }

    public void NextTrack()
    {
        int next = (currentTrackIndex + 1) % musicTracks.Length;
        PlayMusic(next);
    }
}


// -----------------------------
// Setup Instructions for Music
// -----------------------------
// 1. Create an empty GameObject named "MusicManager".
// 2. Add the MusicManager script.
// 3. Add an AudioSource component -> assign it to musicSource.
// 4. Add your background music tracks to the "musicTracks" array.
// 5. To control volume from a UI slider:
// - Add On Value Changed()
// - Drag MusicManager into the event
// - Choose MusicManager → SetMusicVolume(float)




// =============================
// Added: Master, Music, and SFX Volume System
// =============================


// --- Updates to AudioManager.cs ---
// Add these fields:
// public float masterVolume = 1f;
// public float sfxVolume = 1f;
//
// Add these methods:
// public void SetMasterVolume(float value)
// {
// masterVolume = value;
// ApplyVolumes();
// }
//
// public void SetSFXVolume(float value)
// {
// sfxVolume = value;
// ApplyVolumes();
// }
//
// private void ApplyVolumes()
// {
// float finalSFX = masterVolume * sfxVolume;
// if (sfxSource) sfxSource.volume = finalSFX;
// if (sfx3DSource) sfx3DSource.volume = finalSFX;
// }


// --- Updates to MusicManager.cs ---
// Add these fields:
// public float masterVolume = 1f;
// public float musicVolume = 1f;
//
// Add these methods:
// public void SetMasterVolume(float value)
// {
// masterVolume = value;
// ApplyVolume();
// }
//
// public void SetMusicVolume(float value)
// {
// musicVolume = value;
// ApplyVolume();
// }
//
// private void ApplyVolume()
// {
// musicSource.volume = masterVolume * musicVolume;
// }


// --- UI Setup Instructions ---
// Create 3 sliders:
// 1. Master Volume Slider
// 2. Music Volume Slider
// 3. SFX Volume Slider
//
// MASTER SLIDER:
// On Value Changed → AudioManager.SetMasterVolume
// On Value Changed → MusicManager.SetMasterVolume
//
// MUSIC SLIDER:
// On Value Changed → MusicManager.SetMusicVolume
//
// SFX SLIDER:
// On Value Changed → AudioManager.SetSFXVolume