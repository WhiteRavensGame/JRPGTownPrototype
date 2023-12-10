using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WorldVariables
{
    public int Troops;
    public int Moral;
    public int Gold;
    public int Food;
    public int Material;
    public int Silk;
}

public class GameManager : MonoBehaviour
{
    public string levelName = "Unknown";
    public bool LoadGame = false;
    public WorldVariables WVariables = new WorldVariables();

    public void SaveVariables()
    {
        WVariables.Troops = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Troops);
        WVariables.Moral = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Moral);
        WVariables.Gold = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Gold);
        WVariables.Food = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Fish);
        WVariables.Material = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Iron);
        WVariables.Silk = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Silk);
    }
}