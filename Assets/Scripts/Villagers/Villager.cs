using UnityEngine;

public enum Efficiency
{
    None,
    Low,
    Medium,
    Heigh
}

public class Villager : MonoBehaviour
{
    public string villagername;
    public int incomeProfit;
    public int resourceProfit;
    public Resources areaOfEfficiency;
    public Efficiency efficiency;
}
