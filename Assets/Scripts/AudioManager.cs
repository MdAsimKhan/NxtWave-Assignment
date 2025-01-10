using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip endClip; // Audio clip to play at the end
    public AudioClip startClip; // Audio clip to play at the start
    private bool audioPlayed = false; // Flag to ensure the end clip is played only once

    // Play wlecome audio clip at the start
    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the same GameObject
        audioSource.PlayOneShot(startClip);
    }

    // Public method to play a given audio clip
    public void PlayAudioClip(AudioClip clip)
    {
        audioSource.Stop(); // Stop any currently playing audio
        audioSource.PlayOneShot(clip); // Play the provided audio clip once
    }

    // Public method to play the end audio clip, ensuring it is played only once
    public void PlayEndAudio()
    {
        if (!audioPlayed)
        {
            audioSource.Stop(); // Stop any currently playing audio
            audioSource.PlayOneShot(endClip); // Play the end clip once
            audioPlayed = true; // Set the flag to true to prevent replaying the end clip
        }
    }
}
