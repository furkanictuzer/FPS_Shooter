using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableObject : MonoBehaviour
{
    private CollectableObjectSpawner _spawner;
    public event Action Destroyed;

    public virtual void FullyCollected()
    {
        _spawner?.RemoveObject(this);
        _spawner?.SpawnObject();
    }

    public abstract void Collect(Player player);

    protected void DestroyItself()
    {
        Destroyed?.Invoke();
        
        FullyCollected();
        
        Destroy(gameObject);
    }
    
    public void SetSpawner(CollectableObjectSpawner spawner)
    {
        _spawner = spawner;
    }
}
