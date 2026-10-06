using UnityEngine;

public class StatueCaster : MonoBehaviour
{
    [SerializeField] private BoltPool boltPool;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireInterval = 1.5f;
    [SerializeField] private float startDelay = 1f;
    private float timer;

    private void Start()
    {
        timer = startDelay;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            boltPool.GetBolt(firePoint.position, firePoint.rotation);
            timer = fireInterval;
        }
    }
}