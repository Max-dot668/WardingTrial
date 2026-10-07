using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private TrialManager trialManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bolt"))
        {
            trialManager.EndTrial();
        }
    }
}