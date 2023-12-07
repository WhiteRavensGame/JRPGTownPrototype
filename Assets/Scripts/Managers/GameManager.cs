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
}