using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCollectableObjectSpawner : CollectableObjectSpawner
{
    [SerializeField] private float maxSpawnDistance = 5;

    private CollectableSpawnersController _collectableSpawnersController;

    private void Awake()
    {
        _collectableSpawnersController = GetComponentInParent<CollectableSpawnersController>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxSpawnDistance);
    }

    protected override void SpawnObject()
    {
        Vector3 randPosition = GetRandomLocalPosition();
        int attempt = 1;
        
        while (_collectableSpawnersController.TooCloseToSomeObject(randPosition) && attempt < 5)
        {
            randPosition = GetRandomLocalPosition();
            attempt++;
        }

        SpawnObject(randPosition);
    }

    private Vector3 GetRandomLocalPosition()
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
