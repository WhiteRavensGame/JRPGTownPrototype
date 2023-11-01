using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour, IGameModule
{
    //all the amounts of different resources will be here
    //functions for exchanging resources will also be here

    private int _gold;
    private int _food;
    private int _materials;
    private int _cloth;

    #region IGameModule Implementation
    public bool IsInitialized { get { return _isInitialized; } }
    private bool _isInitialized = false;

    public IEnumerator LoadModule()
    {
        Debug.Log("Loading Resource Manager");

        InitializeResources();
        yield return new WaitUntil(() => { return IsInitialized; });

        ServiceLocator.Register<ResourceManager>(this);
        yield return null;
    }
    private void InitializeResources()
    {
        _isInitialized = true;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGold(int gold)
    {
        _gold += gold;
    }
}
