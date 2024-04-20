using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    public static T instance { get; private set; }
    public bool _DontDestroyOnLoad;

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        if (_DontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }

        instance = this as T;
    }
}

