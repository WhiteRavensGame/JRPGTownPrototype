using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour, IGameModule
{
    //all the amounts of different resources will be here
    //functions for exchanging resources will also be here

    private int _gold = 1500;
    private int _fish = 0;
    private int _iron = 0;
    private int _silk = 0;

    public int Fish { get { return _fish; } }
    public int Iron { get { return _iron; } }
    public int Silk { get { return _silk; } }

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

    #region Add Resources to Total
    public void AddGold(int gold)
    {
        _gold += gold;
    }

    public void AddFish(int amount)
    {
        _fish += amount;
    }

    public void AddIron(int amount)
    {
        _iron += amount;
    }

    public void AddSilk(int amount)
    {
        _silk += amount;
    }
    #endregion

    public bool CanUseGold(int amount)
    {
        if (_gold - amount < 0)
            return false;

        return true;
    }
}
