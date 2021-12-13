using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonBehaviour : MonoBehaviour
{
    public abstract void Init();
}

public abstract class SingletonBehaviour<T> : SingletonBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    protected abstract void AwakeChild();

    void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);

            return;
        }

        _instance = this as T;

        AwakeChild();
    }
}
