// -----------------------------
// File: MusicManager.cs
//
// Co-created with ChatGPT
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
