using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the UI Text component to display the timer
    private float elapsedTime = 0f; // Elapsed time in seconds
    private bool isTimerRunning = true; // Control variable for starting/stopping the timer
    private float finalTime = 0f; // Variable to store the final time

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = (int)(elapsedTime / 60f);
        int seconds = (int)(elapsedTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method to stop the timer and set the final time
    public void StopTimer()
    {
        isTimerRunning = false;
        finalTime = elapsedTime;
    }

    // Method to retrieve the final time
    public float GetFinalTime()
    {
        return finalTime;
    }
}
