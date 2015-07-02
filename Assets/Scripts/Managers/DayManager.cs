using UnityEngine;
using System.Collections;

public class DayManager : Singleton<DayManager> {

    public int innEarnings;
    public int itemEarnings;
    public int weaponEarnings;

    public int totalEarnings;

    public int CalculateInnEarnings(int level, int villagersCount, int customersCount)
    {
        int baseEarning = 100 + (50 * level);
        //50% to 200% depending on number of villagers/helpers.
        float villagerBonus = 0.5f + Mathf.Min(villagersCount / (level * 5), 1.5f);

        Debug.Log("INN: " + baseEarning + "x" + customersCount + "x" + villagerBonus);
        return Mathf.RoundToInt(baseEarning * customersCount * villagerBonus);

    }

    public int CalculateItemShopEarnings(int level, int villagersCount, int customersCount)
    {
        //Currently just randomizes. In the future, uses the value the items

        int baseEarning = Mathf.RoundToInt(Random.Range(level * 120, level * 180));
        //50% to 200% depending on number of villagers/helpers.
        float villagerBonus = 0.5f + Mathf.Min(villagersCount / (level * 5), 1.5f);

        Debug.Log("ITEM: " + baseEarning + "x" + customersCount + "x" + villagerBonus);
        return Mathf.RoundToInt(baseEarning * customersCount * villagerBonus);

    }

    public int CalculateWeaponShopEarnings(int level, int villagersCount, int customersCount)
    {
        //Currently just randomizes. In the future, uses the value the weapons
        int baseEarning = Mathf.RoundToInt(Random.Range(level * 50, level * 300));
        float villagerBonus = 0.5f + Mathf.Min(villagersCount / (level * 5), 1.5f);

        Debug.Log("WEAPON: " + baseEarning + "x" + customersCount + "x" + villagerBonus);
        return Mathf.RoundToInt(baseEarning * customersCount * villagerBonus);

    }

    public int CalculateDailyEarnings(int innVillagers, int itemVillagers, int weaponVillagers, int innCustomers, int itemCustomers, int weaponCustomers)
    {
        //Currently randomizes customers?

        int _innEarnings = CalculateInnEarnings(GameManager.Instance.playerStats.levelInn, innVillagers, innCustomers);
        int _itemEarnings = CalculateItemShopEarnings(GameManager.Instance.playerStats.levelItem, itemVillagers, itemCustomers);
        int _weaponEarnings = CalculateWeaponShopEarnings(GameManager.Instance.playerStats.levelWeapon, weaponVillagers, weaponCustomers);

        //Store each individual value
        innEarnings = _innEarnings;
        itemEarnings = _itemEarnings;
        weaponEarnings = _weaponEarnings;
        totalEarnings = (innEarnings + itemEarnings + weaponEarnings);

        return totalEarnings;
    }
}