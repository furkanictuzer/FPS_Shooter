using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectSpawner : MonoBehaviour
{
    [SerializeField] protected List<CollectableObject> objectsToSpawn = new List<CollectableObject>();

    [SerializeField] private Transform spawnLocation;
    
    protected int _spawnedObjectCount = 0;

    public virtual void SpawnObject()
    {
        SpawnObject(spawnLocation.position);
    }

    public void AddObject(CollectableObject obj)
    {
        if (!objectsToSpawn.Contains(obj))
        {
            objectsToSpawn.Add(obj);
        }
    }
    
    public void RemoveObject(CollectableObject obj)
    {
        if (objectsToSpawn.Contains(obj))
        {
            objectsToSpawn.Remove(obj);
        }
    }
    
    protected void SpawnObject(Vector3 location)
    {
        GameObject prefabObject = objectsToSpawn[_spawnedObjectCount % objectsToSpawn.Count].gameObject;

        CollectableObject spawnedObject = Instantiate(
                prefabObject, 
                location, 
                Quaternion.identity, 
                transform)
            .GetComponent<CollectableObject>();

        spawnedObject.SetSpawner(this);

        AddObject(spawnedObject);
    }
}
