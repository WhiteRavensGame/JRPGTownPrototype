using UnityEngine;

public enum Efficiency
{
    None,
    Low,
    Medium,
    Heigh
}

[System.Serializable]
public class Villager : MonoBehaviour
{
    public string villagername;
    public int incomeProfit;
    public int resourceProfit;
    public Resources areaOfEfficiency;
    public Efficiency efficiency;


}