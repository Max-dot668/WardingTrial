using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TrialManager : MonoBehaviour
{
    private const string BestTimeKey = "BestTime";

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject failPanel;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private string menuSceneName = "MainMenu";
    private float survivalTime;
    private bool trialOver;

    private void Update()
    {
        if (trialOver)
        {
            return;
        }
        survivalTime += Time.deltaTime;
        timerText.text = survivalTime.ToString("F1");
    }

    public void EndTrial()
    {
        if (trialOver)
        {
            return;
        }
        trialOver = true;
        Time.timeScale = 0f;
        failPanel.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat(BestTimeKey, 0f);
        if (survivalTime > bestTime)
        {
            PlayerPrefs.SetFloat(BestTimeKey, survivalTime);
            PlayerPrefs.Save();
            resultText.text = "New best! You lasted " + survivalTime.ToString("F1") + " s";
        }
        else
        {
            resultText.text = "You lasted " + survivalTime.ToString("F1") + " s";
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public bool IsTrialOver()
    {
        return trialOver;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}