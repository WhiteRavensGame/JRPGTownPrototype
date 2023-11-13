using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfWeekPanel : MonoBehaviour
{
    [SerializeField] GameObject _resourcePanel;
    [SerializeField] GameObject _buildingPanel;

    public void GoToBuildingPanel()
    {
        _resourcePanel.SetActive(false);
        _buildingPanel.SetActive(true);
    }

    public void GoToResourcePanel()
    {
        _resourcePanel.SetActive(true);
        _buildingPanel.SetActive(false);
    }

    public void EndWeek()
    {
        ServiceLocator.Get<PlayerManager>().gameState = GameStates.MainScreen;
        this.gameObject.SetActive(false);
    }
}
