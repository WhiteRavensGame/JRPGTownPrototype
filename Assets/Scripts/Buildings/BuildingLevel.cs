using UnityEngine;

public abstract class BuildingLevel: ScriptableObject
{
    [Header("Building Settings")]
    [SerializeField]
    private Resources resources;
    [SerializeField]
    private Sprite buildingSprite;
    [SerializeField]
    private int maxVillagers;

    [Space, Header("Panel Settings")] 
    [SerializeField, TextArea(3, 10)]
    private string panelText;
    [SerializeField]
    private string buttonText;

    public Sprite getbuildingSprite { get { return buildingSprite; } }
    public string getPanelText { get { return panelText; } }
    public string getButtonText { get { return buttonText; } }
    public int getMaxVillagers { get { return maxVillagers; } }

    public abstract void Execute();
    public abstract void LevelUp(Building building);
}
