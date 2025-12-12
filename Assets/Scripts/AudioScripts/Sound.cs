// -----------------------------
// File: Sound.cs
// Generated using ChatGPT
// -----------------------------
using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "Audio/Sound")]
public class Sound : ScriptableObject
{
    public string soundName;
    public AudioClip clip;

    [Range(0f, 1f)] public float volume = 1f;
    [Range(.5f, 1.5f)] public float pitch = 1f;

    public bool loop = false;
    public bool spatialized = false;

    public float spatialBlend => spatialized ? 1f : 0f;
}