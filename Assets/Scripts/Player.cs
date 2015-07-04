using UnityEngine;
using System.Collections;

public class Player {

    public int dayCount;
    public int villagersCount;
    public int gold;

    public int levelInn;
    public int levelItem;
    public int levelWeapon;
    public int levelTavern;

    public Player()
    {
        dayCount = 1;
        villagersCount = 25;
        gold = 0;

        levelInn = 1;
        levelItem = 1;
        levelWeapon = 1;
        levelTavern = 1;
    }

}
