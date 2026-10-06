using UnityEngine;
using System.Collections.Generic;

public class BoltPool : MonoBehaviour
{
    [SerializeField] private GameObject boltPrefab;
    [SerializeField] private int poolSize = 20;
    private List<GameObject> bolts = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bolt = Instantiate(boltPrefab, transform);
            bolt.SetActive(false);
            bolts.Add(bolt);
        }
    }

    public GameObject GetBolt(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < bolts.Count; i++)
        {
            GameObject bolt = bolts[i];
            if (!bolt.activeInHierarchy)
            {
                bolt.transform.SetPositionAndRotation(position, rotation);
                bolt.SetActive(true);
                return bolt;
            }
        }
        return null;
    }
}
