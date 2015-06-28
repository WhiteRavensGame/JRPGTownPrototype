using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    public Player playerStats;

	// Use this for initialization
	void Start () {
	    
	}  
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ProcessSimulation()
    {
        
    }

    public int CalculateInnEarnings(int level, int villagersCount, int customersCount)
    {
        int baseEarning = 100 * (50 * level);
        //50% to 200% depending on number of villagers/helpers.
        float villagerBonus = 0.5f + Mathf.Min(villagersCount / (level * 5), 1.5f);

        return Mathf.RoundToInt(baseEarning * customersCount * villagerBonus);
        
    }

    public int CalculateItemShopEarnings(int level, int villagersCount, int customersCount)
    {
        //Currently just randomizes. In the future, uses the value the items

        int baseEarning = Mathf.RoundToInt(Random.Range(level * 120, level * 180) * customersCount);
        //50% to 200% depending on number of villagers/helpers.
        float villagerBonus = 0.5f + Mathf.Min(villagersCount / (level * 5), 1.5f);

        return Mathf.RoundToInt(baseEarning * customersCount * villagerBonus);

    }

    public int CalculateWeaponShopEarnings(int level, int villagersCount, int customersCount)
    {
        //Currently just randomizes. In the future, uses the value the weapons
        int baseEarning = Mathf.RoundToInt( Random.Range(level * 50, level * 300) * customersCount );
        float villagerBonus = 0.5f + Mathf.Min(villagersCount / (level * 5), 1.5f);

        return Mathf.RoundToInt(baseEarning * customersCount * villagerBonus);

    }

    public void CalculateDailyEarnings()
    {

    }
}
