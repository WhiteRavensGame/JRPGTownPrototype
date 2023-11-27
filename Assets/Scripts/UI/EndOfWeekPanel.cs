using UnityEngine;
using TMPro;

public class EndOfWeekPanel : MonoBehaviour
{
    [SerializeField] GameObject _resourcePanel;
    [SerializeField] GameObject _buildingPanel;
    [SerializeField] GameObject _mainCanvas;
    [SerializeField] private TextMeshProUGUI villagersCount;

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
        _mainCanvas.SetActive(true);
        int week = ServiceLocator.Get<TimeManager>().GetWeek();
        ServiceLocator.Get<EventManager>().WeeklyEvent(week);
    }

    public void UpdateVillagersNums()
    {
        villagersCount.text = ServiceLocator.Get<VillageManager>().GetVillagersAmt();
    }
}
