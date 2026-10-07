using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private const string BestTimeKey = "BestTime";

    [SerializeField] private string gameSceneName = "Game";
    [SerializeField] private TMP_Text bestTimeText;

    private void Start()
    {
        float bestTime = PlayerPrefs.GetFloat(BestTimeKey, 0f);
        if (bestTime > 0f)
        {
            bestTimeText.text = "Best: " + bestTime.ToString("F1") + " s";
        }
        else
        {
            bestTimeText.text = "No trial attempted yet";
        }
    }

    public void BeginTrial()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}