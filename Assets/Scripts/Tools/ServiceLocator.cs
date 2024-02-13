﻿using System.Collections.Generic;
using UnityEngine;

static public class ServiceLocator
{
    static private readonly Dictionary<System.Type, object> m_systems = new Dictionary<System.Type, object>();

    static public T Register<T>(object target)
    {
        if (m_systems.ContainsKey(typeof(T)))
        {
            Debug.Log("There is already a type of : " + typeof(T) + " that exists");
        }
        else
        {
            Debug.Log("Registering " + typeof(T));
            m_systems.Add(typeof(T), target);
        }
        return (T)target;
    }

    static public T Get<T>()
    {
        object ret = null;
        m_systems.TryGetValue(typeof(T), out ret);
        if (ret == null)
        {
            Debug.Log("Could not find [" + (typeof(T)) + "] as a registered system");
        }
        return (T)ret;
    }

    static public void Unregister<T>()
    {
        if (Contains<T>())
        {
            m_systems.Remove(typeof(T));
        }
        else
        {
            Debug.Log($"Couldn't Find registered system of type {typeof(T)} to remove");
        }
    }

    static public void UnregisterAll()
    {
        m_systems.Clear();
    }

    static public bool Contains<T>()
    {
        return (m_systems.ContainsKey(typeof(T)));
    }
}
