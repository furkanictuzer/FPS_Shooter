using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectableSpawnersController : MonoBehaviour
{
    [SerializeField] private List<CollectableObjectSpawner> spawners = new List<CollectableObjectSpawner>();

    private void Awake()
    {
        spawners = GetComponentsInChildren<CollectableObjectSpawner>().ToList();
    }
    
    public bool TooCloseToSomeObject(Vector3 localPosition)
    {
        List<CollectableObject> spawnedObjects = new List<CollectableObject>();

        foreach (var spawner in spawners)
        {
            spawnedObjects.AddRange(spawner.SpawnedObjects);
        }
        
        float treshold = 1;

        foreach (var obj in spawnedObjects)
        {
            float distance = Vector3.Distance(obj.transform.localPosition, localPosition);

            if (distance <= treshold)
            {
                return true;
            }
        }

        return false;
    }
}
