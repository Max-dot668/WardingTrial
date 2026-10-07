using UnityEngine;

public class TrialManager : MonoBehaviour
{
    private bool trialOver;

    public void EndTrial()
    {
        if (trialOver)
        {
            return;
        }
        trialOver = true;
        Time.timeScale = 0f;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}