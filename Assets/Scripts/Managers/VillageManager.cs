using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    //all the different types of buildings present in the village will be here
    //the amount of villagers for allocating villagers will also be here

    private int _morale;

    private int _vTotal;
    private int _vAllocated;
    private int _vFood;
    private int _vMaterial;
    private int _vCloth;

    #region IGameModule Implementation
    public bool IsInitialized { get { return _isInitialized; } }
    private bool _isInitialized = false;

    public IEnumerator LoadModule()
    {
        Debug.Log("Loading Village Manager");

        InitializeVillage();
        yield return new WaitUntil(() => { return IsInitialized; });

        ServiceLocator.Register<VillageManager>(this);
        yield return null;
    }
    private void InitializeVillage()
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

    public void AddVillagers(int amount)
    {
        _vTotal += amount;
    }

    public void AddVillagerInn(int amount)
    {
        if (_vAllocated + amount >= _vTotal)
            return;

        _vFood += amount;
        _vAllocated += amount;
    }

    public void AddVillagerSmith(int amount)
    {
        if (_vAllocated + amount >= _vTotal)
            return;

        _vMaterial += amount;
        _vAllocated += amount;
    }

    public void AddVillagerSilk(int amount)
    {
        if (_vAllocated + amount >= _vTotal)
            return;

        _vCloth += amount;
        _vAllocated += amount;
    }

    public void RemoveVillagerInn(int amount)
    {
        if (_vAllocated - amount < 0)
            return;

        _vFood -= amount;
        _vAllocated -= amount;
    }

    public void RemoveVillagerSmith(int amount)
    {
        if (_vAllocated - amount < 0)
            return;

        _vMaterial -= amount;
        _vAllocated -= amount;  
    }

    public void RemoveVillagerSilk(int amount)
    {
        if (_vAllocated - amount < 0)
            return;

        _vCloth -= amount;  
        _vAllocated -= amount;
    }
}
