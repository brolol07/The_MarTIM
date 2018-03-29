﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{

    static T s_instance;

    public static T Instance
    {
        get
        {
            return s_instance ?? new GameObject(typeof(T).Name).AddComponent<T>();
        }
    }

    protected virtual void Awake()
    {
        if (s_instance)
        {
            Debug.LogWarning("A Singleton instance was previously initialized.");
            Destroy(gameObject);
            return;
        }

        s_instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }

    protected virtual void OnEnable()
    {
        if (!s_instance)
            s_instance = GetComponent<T>();
    }

    protected virtual void OnDestroy()
    {
        if (s_instance != GetComponent<T>())
            return;
        

        s_instance = null;
    }
}
