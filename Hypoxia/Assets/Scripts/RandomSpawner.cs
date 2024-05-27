using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnableItem
    {
        public GameObject itemPrefab;
        public float minDistanceFromCenter = 100f;
        public float maxDistanceFromCenter = 1000f;
        public int numberOfItems = 1;
    }

    public SpawnableItem[] itemsToSpawn;
    public Transform centerPoint;

    void Start()
    {
        foreach (var item in itemsToSpawn)
        {
            for (int i = 0; i < item.numberOfItems; i++)
            {
                SpawnItem(item);
            }
        }
    }

    void SpawnItem(SpawnableItem item)
    {
        Vector3 randomPosition = Random.insideUnitSphere * item.maxDistanceFromCenter + centerPoint.position;
        while (Vector3.Distance(randomPosition, centerPoint.position) < item.minDistanceFromCenter)
        {
            randomPosition = Random.insideUnitSphere * item.maxDistanceFromCenter + centerPoint.position;
        }

        Instantiate(item.itemPrefab, randomPosition, Quaternion.identity, transform);
    }
}