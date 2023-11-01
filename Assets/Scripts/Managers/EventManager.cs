using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region IGameModule Implementation
    public bool IsInitialized { get { return _isInitialized; } }
    private bool _isInitialized = false;

    public IEnumerator LoadModule()
    {
        Debug.Log("Loading Event Manager");

        InitializeEvents();
        yield return new WaitUntil(() => { return IsInitialized; });

        ServiceLocator.Register<EventManager>(this);
        yield return null;
    }
    private void InitializeEvents()
    {
        _isInitialized = true;
    }
    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
