using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Building : MonoBehaviour
{
    [Header("Building Settings"), SerializeField]
    private int buildingLevel;
    [SerializeField]
    private List<BuildingLevel> buildingLevelObjects;

    [Space, Header("Panel Settings"), SerializeField]
    private GameObject infoPanel;
    [SerializeField]
    private TextMeshProUGUI panelText;
    [SerializeField]
    private TextMeshProUGUI buttonText;

    public void ActivatePanel(bool activation)
    {
        infoPanel.SetActive(activation);
    }

    public void ChangeInfoString(int currentLevel)
    {
        if (currentLevel != buildingLevel)
        {
            panelText.text = buildingLevelObjects[buildingLevel - 1].getPanelText;
            buttonText.text = buildingLevelObjects[buildingLevel - 1].getButtonText;
            currentLevel = buildingLevel;
        }
    }

    public void Execute()
    {
        buildingLevelObjects[buildingLevel - 1].Execute();
    }
}
