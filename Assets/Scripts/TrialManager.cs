using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TrialManager : MonoBehaviour
{
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
        resultText.text = "You lasted " + survivalTime.ToString("F1") + " s";
        failPanel.SetActive(true);
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