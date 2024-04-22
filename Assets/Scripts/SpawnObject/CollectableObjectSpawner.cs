using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CollectableObjectSpawner : MonoBehaviour
{
    [SerializeField] protected List<CollectableObject> objectsToSpawn = new List<CollectableObject>();
    [SerializeField] protected List<CollectableObject> spawnedObjects = new List<CollectableObject>();
    
    [SerializeField] private Transform spawnLocation;
    [Space] 
    [SerializeField] protected float timeBetweenTwoSpawn = 3;
    [Space]
    [SerializeField] protected int initialSpawnCount = 3;
    
    protected int _spawnedObjectCount = 0;

    public List<CollectableObject> SpawnedObjects => spawnedObjects;

    private void Start()
    {
        SpawnObject(initialSpawnCount);
    }

    public virtual void SpawnObject(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnObject();
        }
    }
    
    public virtual void SpawnObject()
    {
        SpawnObject(spawnLocation.position);
    }

    public void AddObject(CollectableObject obj)
    {
        if (!spawnedObjects.Contains(obj))
        {
            spawnedObjects.Add(obj);
        }
    }
    
    public void RemoveObject(CollectableObject obj)
    {
        if (spawnedObjects.Contains(obj))
        {
            spawnedObjects.Remove(obj);
        }
    }

    public void SpawnObjectWithDelay()
    {
        SpawnObjectWithDelay(timeBetweenTwoSpawn);
    }
    public void SpawnObjectWithDelay(float delayInSec)
    {
        StartCoroutine(SpawnObjectWithDelayCoroutine(delayInSec));
    }
    private IEnumerator SpawnObjectWithDelayCoroutine(float delayInSec)
    {
        yield return new WaitForSeconds(delayInSec);
        
        SpawnObject();
    }
    
    protected void SpawnObject(Vector3 localPos)
    {
        GameObject prefabObject = objectsToSpawn[_spawnedObjectCount % objectsToSpawn.Count].gameObject;

        CollectableObject spawnedObject = Instantiate(
                prefabObject, 
                transform)
            .GetComponent<CollectableObject>();

        spawnedObject.transform.localPosition = localPos;
        spawnedObject.transform.rotation = Quaternion.identity;
        
        spawnedObject.SetSpawner(this);

        AddObject(spawnedObject);
    }
}
