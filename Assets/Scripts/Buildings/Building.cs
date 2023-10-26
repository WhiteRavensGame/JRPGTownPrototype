using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [Header("Building Settings"), SerializeField]
    private int buildingLevel;
    [SerializeField]
    private List<BuildingLevel> buildingLevelObjects;

    [Space, Header("Panel Settings"), SerializeField]
    GameObject infoPanel;

    private void Awake()
    {
        
    }

    private void OnMouseDown()
    {
        infoPanel.SetActive(true);
        //buildingLevelObjects[buildingLevel - 1].Execute();
    }

    public void OnClosePanel()
    {
        infoPanel.SetActive(false);
    }
}
