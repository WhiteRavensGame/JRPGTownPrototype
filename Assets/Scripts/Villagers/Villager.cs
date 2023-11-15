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
    public int profit;
    public Resources areaOfEfficiency;
    public Efficiency efficiency;
}
