using UnityEngine;
using System.Collections;
//using Oculus.Interaction.

public class RotateObject : MonoBehaviour
{
    public float degrees; // Degrees to rotate the object
    public float duration; // Duration over which the rotation occurs
    public AudioManager audioManager; // Reference to the AudioManager to play audio clips
    public AudioClip gesture2Clip; // Audio clip for the next gesture
    private bool isRotating = false; // Flag to check if the object is currently rotating
    private bool audioPlayed = false; // Flag to ensure the audio is played only once

    // Public method to start rotating the object by specified degrees in the given direction
    public void RotateByDegrees(bool rotateLeft)
    {
        if (!isRotating)
        {
            StartCoroutine(RotateOverTime(rotateLeft)); // Start the rotation coroutine
            if (!audioPlayed)
            {
                audioManager.PlayAudioClip(gesture2Clip); // Play the gesture audio clip if not already played
                audioPlayed = true; // Set the flag to true to prevent replaying the audio
            }
        }
    }

    // Coroutine to handle the smooth rotation over time
    private IEnumerator RotateOverTime(bool rotateLeft)
    {
        isRotating = true; // Set the flag to indicate rotation is in progress
        float elapsed = 0f;
        float targetDegrees = rotateLeft ? -degrees : degrees; // Use a local variable to avoid modifying the original degrees
        Quaternion initialRotation = transform.rotation; // Store the initial rotation
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, targetDegrees, 0); // Calculate the target rotation

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsed / duration); // Smoothly interpolate the rotation
            elapsed += Time.deltaTime; // Increment the elapsed time
            yield return null; // Wait for the next frame
        }

        transform.rotation = targetRotation; // Ensure the final rotation is set to the target rotation
        isRotating = false; // Reset the flag to indicate rotation is complete
    }
}

