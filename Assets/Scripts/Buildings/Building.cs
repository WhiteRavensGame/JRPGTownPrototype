using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Building : MonoBehaviour
{
    [Header("Building Settings"), SerializeField]
    private int buildingLevel;
    [SerializeField]
    private BuildingType buildingType;
    [SerializeField]
    private List<BuildingLevel> buildingLevelObjects;

    private SpriteRenderer buildingSR;

    [Space, Header("Panel Settings"), SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private TextMeshProUGUI panelText;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    private void Awake()
    {
        buildingSR = GetComponent<SpriteRenderer>();
        ChangeBuilding();
    }

    public void ActivatePanel(bool activation)
    {
        infoPanel.SetActive(activation);
    }

    public void ChangeBuilding()
    {
        panelText.text = buildingLevelObjects[buildingLevel - 1].getPanelText;
        buttonText.text = buildingLevelObjects[buildingLevel - 1].getButtonText;
        buttonText.text = buildingLevelObjects[buildingLevel - 1].getButtonText;
        buildingSR.sprite = buildingLevelObjects[buildingLevel - 1].getbuildingSprite;
    }

    public void Execute()
    {
        buildingLevelObjects[buildingLevel - 1].Execute();

        if (buildingLevel + 1 <= buildingLevelObjects.Count)
        {
            ++buildingLevel;
            ChangeBuilding();
        }
    }

    public int GetMaxVillagers()
    {
        return buildingLevelObjects[buildingLevel - 1].getMaxVillagers;
    }

    public BuildingType GetBuildingType()
    {
        return buildingType;
    }
}
