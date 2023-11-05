using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
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


    public void AddGold(int gold)
    {
        _gold += gold;
    }

    public void AddResource(Resources resource, int amount)
    {
        switch (resource)
        {
            case Resources.Fish:
                _fish -= amount;
                break;
            case Resources.Iron:
                _iron -= amount;
                break;
            case Resources.Silk:
                _silk -= amount;
                break;
            case Resources.Gold:
                _gold -= amount;
                break;
            default:
                break;
        }
    }

    public bool CanUseGold(int amount)
    {
        if (_gold - amount < 0)
            return false;

        return true;
    }

    public int GetResourceAmt(Resources resource)
    {
        switch(resource)
        {
            case Resources.Fish:
                return Fish;
            case Resources.Iron:
                return Iron;
            case Resources.Silk:
                return Silk;
            default:
                return 0;
        }
    }

    public void UseResources(Resources resource, int amount)
    {
        switch (resource)
        {
            case Resources.Fish:
                _fish -= amount;
                break;
            case Resources.Iron:
                _iron -= amount;
                break;
            case Resources.Silk:
                _silk -= amount;
                break;
            default:
                break;
        }
    }
}
