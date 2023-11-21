using UnityEngine;

public enum Efficiency
{
    None,
    Low,
    Medium,
    Heigh
}

[System.Serializable]
public struct VillagerSaveData
{
    public string s_Villagername;
    public int s_IncomeProfit;
    public int s_ResourceProfit;
    public Resources s_AreaOfEfficiency;
    public Efficiency s_Efficiency;
}

[System.Serializable]
public class Villager : MonoBehaviour
{
    public string villagername;
    public int incomeProfit;
    public int resourceProfit;
    public Resources areaOfEfficiency;
    public Efficiency efficiency;

    public VillagerSaveData ToSaveData()
    {
        return new VillagerSaveData()
        {
            s_Villagername = villagername,
            s_IncomeProfit = incomeProfit,
            s_ResourceProfit = resourceProfit,
            s_AreaOfEfficiency = areaOfEfficiency,
            s_Efficiency = efficiency
        };
    }

    public void LoadData(VillagerSaveData saveData)
    {
        villagername = saveData.s_Villagername;
        incomeProfit = saveData.s_IncomeProfit;
        resourceProfit = saveData.s_ResourceProfit;
        areaOfEfficiency = saveData.s_AreaOfEfficiency;
        efficiency = saveData.s_Efficiency;
    }

}