using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCollectableObjectSpawner : CollectableObjectSpawner
{
    [SerializeField] private float maxSpawnDistance = 5;

    public override void SpawnObject()
    {
        Vector3 randPosition = GetRandomPosition();

        SpawnObject(randPosition);
    }

    private Vector3 GetRandomPosition()
    {
        int randomDegree = Random.Range(0, 360);
        float randomRadian = randomDegree * Mathf.Deg2Rad;
        float randDistance = Random.Range(0f, maxSpawnDistance);

        Vector3 position = new Vector3(
            Mathf.Cos(randomRadian) * randDistance, 
            0,
            Mathf.Sin(randomRadian) * randDistance);

        return position;
    }
}
