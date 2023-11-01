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

    #region Use Resources
    public bool UseGold(int amount)
    {
        if (_gold - amount < 0)
            return false;

        _gold -= amount;
        return true;
    }

    public bool UseFish(int amount)
    {
        if (_fish - amount < 0)
            return false;

        _fish -= amount;
        return true;
    }

    public bool UseIron(int amount)
    {
        if (_iron - amount < 0)
            return false;

        _iron -= amount;
        return true;
    }

    public bool UseSilk(int amount)
    {
        if (_silk - amount < 0)
            return false;

        _silk -= amount;
        return true;
    }
    #endregion

}
