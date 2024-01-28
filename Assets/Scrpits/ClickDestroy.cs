using UnityEngine;

public class ClickDestroy : MonoBehaviour
{
    public AudioClip clickSound;  // Assign the audio clip in the Unity Editor
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If Audio Source is on a different GameObject
            audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        }
    }

    void OnMouseDown()
    {
        // Play the click sound
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        // Destroy the GameObject
        Destroy(gameObject);
    }
}
