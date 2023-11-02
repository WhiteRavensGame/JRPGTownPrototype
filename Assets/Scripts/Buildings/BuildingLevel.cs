using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum Resources { Fish, RawMaterial, Silk }

public abstract class BuildingLevel: ScriptableObject
{
    [Header("Building Settings")]
    [SerializeField] private Resources resources;
    [SerializeField] private Sprite buildingSprite;
    [SerializeField] private int maxVillagers;
    [SerializeField] private int resourcesProduced;
    [SerializeField] private int upgradeCost;
    [SerializeField] protected BuildingLevel buildingNextLevel;

    [Space, Header("Panel Settings")] 
    [SerializeField, TextArea(3, 10)] private string panelText; 
    [SerializeField, TextArea(3, 10)] private string minResourcesInfo;
    [SerializeField, TextArea(3, 10)] private string maxResourcesInfo;
    [SerializeField] private Sprite vendorImage;

    public Sprite getbuildingSprite { get { return buildingSprite; } }
    public int getMaxVillagers { get { return maxVillagers; } }

    public string getPanelText { get { return panelText; } }
    public string getMinResourcesInfo { get { return minResourcesInfo; } }
    public string getMaxResourcesInfo { get { return maxResourcesInfo; } }
    public Sprite getVendorImage { get { return vendorImage; } }

    public abstract void Execute();
    public abstract void LevelUp(Building building);
}
