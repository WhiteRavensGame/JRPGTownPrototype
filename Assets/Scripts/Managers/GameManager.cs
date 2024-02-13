using UnityEngine;
using System.Collections.Generic;

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
    public Dictionary<string, bool> endingsCollected = new();

    private void Start()
    {
        var newData = ServiceLocator.Get<SaveSystem>().Load<string[]>("EndVsave.doNotOpen");
        if (!EqualityComparer<string[]>.Default.Equals(newData, default))
        {
            foreach(var ending in newData)
            {
                endingsCollected.Add(ending, true);
            }
        }
    }

    public void SaveVariables()
    {
        WVariables.Troops = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Troops);
        WVariables.Moral = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Moral);
        WVariables.Gold = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Gold);
        WVariables.Food = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Fish);
        WVariables.Material = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Iron);
        WVariables.Silk = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Silk);
    }

    public void SaveEnding(string endingName)
    {
        if(!endingsCollected.ContainsKey(endingName))
        {
            endingsCollected.Add(endingName, true);
        }
    }

    public void Save()
    {
        if(endingsCollected.Count < 0)
        {
            return;
        }

        string[] endings = new string[endingsCollected.Count];
        int i = 0;
        foreach(var end in endingsCollected)
        {
            endings[i++] = end.Key;
        }

        ServiceLocator.Get<SaveSystem>().Save<string[]>(endings, "EndVsave.doNotOpen");
    }
}