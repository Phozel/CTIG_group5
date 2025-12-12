// =============================
// How to Use Audio System:
// =============================
// 1. Create a folder: Assets/Audio/Sounds
// 2. Right-click → Create → Audio → Sound
// 3. Configure clip, volume, pitch
// 4. Create an AudioManager prefab:
// - Add AudioManager.cs
// - Add 2 AudioSources (name them SFX_2D and SFX_3D)
// - Assign them in the inspector
// 5. Add your Sound objects to the "sounds" list
// 6. Example of playing sounds from any script:
// AudioManager.Instance.Play("Jump");
//
// Or for 3D:
// AudioManager.Instance.PlayAtPosition("Explosion", transform.position);
//

All scripts for the audio were generated using ChatGPT