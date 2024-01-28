using UnityEngine;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText; // Reference to the UI Text component to display the final time

    public void ShowGameOver(float finalTime)
    {
        finalTimeText.text = "Score: " + FormatTime(finalTime);
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = (int)(timeInSeconds / 60f);
        int seconds = (int)(timeInSeconds % 60f);
        int milliseconds = (int)((timeInSeconds * 1000f) % 1000f);
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
