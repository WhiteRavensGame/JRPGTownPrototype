using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public GameObject EmptyVillager;
    public GameObject AIVillager;
    public List<Building> Buildings;

    public Building GetBuidlding(string name)
    {
        switch (name)
        {
            case "INN":
                return Buildings[0];
            case "Fishery":
                return Buildings[1];
            case "Mining":
                return Buildings[2];
            case "Smithy":
                return Buildings[3];
            case "SilkFarm":
                return Buildings[4];
            case "SilkShop":
                return Buildings[5];
                default: return null;
        }
    }

    public Building GetRandBuidlding()
    {
        return Buildings[Random.Range(0, Buildings.Count)];
    }
}
