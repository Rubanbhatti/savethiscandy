using UnityEngine;

public class CandyCollector : MonoBehaviour
{
    public Timer timer; // Reference to the Timer script
    public int candiesToCollect = 10; // Number of candies to trigger Game Over
    public GameObject gameOverPanel; // Reference to the Game Over panel

    private int collectedCandies = 0;
    private bool isGameOver = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ant") && !isGameOver)
        {
            collectedCandies++;
            Destroy(gameObject);

            if (collectedCandies >= candiesToCollect)
            {
                ShowGameOverPanel();
            }
        }
    }

    private void ShowGameOverPanel()
    {
        isGameOver = true;
        if (gameOverPanel != null)
        {
            timer.StopTimer(); // Stop the timer and capture the final time
            float finalTime = timer.GetFinalTime(); // Retrieve the final time from the Timer script
            gameOverPanel.GetComponent<GameOverPanel>().ShowGameOver(finalTime);
            gameOverPanel.SetActive(true);
        }
    }

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
}
