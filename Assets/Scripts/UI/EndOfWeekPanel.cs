using UnityEngine;
using TMPro;

public class EndOfWeekPanel : MonoBehaviour
{
    [SerializeField] GameObject _resourcePanel;
    [SerializeField] GameObject _buildingPanel;
    [SerializeField] GameObject _mainCanvas;
<<<<<<< Updated upstream
    [SerializeField] private TextMeshProUGUI villagersCount;
=======
    [SerializeField] private TextMeshProUGUI _villagersCount;
    [SerializeField] private TextMeshProUGUI _villagersMoral;
    [SerializeField] private TextMeshProUGUI _silkText;
    [SerializeField] private TextMeshProUGUI _fishText;
    [SerializeField] private TextMeshProUGUI _ironText;
    [SerializeField] private TextMeshProUGUI _troopsText;
    [SerializeField] private TextMeshProUGUI _goldText;
>>>>>>> Stashed changes

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
        ServiceLocator.Get<VillageManager>().InstantiateVillagers();
    }

    public void UpdateVillagersNums()
    {
<<<<<<< Updated upstream
        villagersCount.text = ServiceLocator.Get<VillageManager>().GetVillagersAmt();
=======
        _villagersCount.text = ServiceLocator.Get<VillageManager>().GetVillagersAmt();
        _villagersMoral.text = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Moral) + "%";
    }

    public void UpdateResources()
    {
        ServiceLocator.Get<ResourceManager>().UpdateResourceText();
        _silkText.text = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Silk).ToString();
        _fishText.text = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Fish).ToString();
        _ironText.text = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Iron).ToString();
        _troopsText.text = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Troops).ToString();
        _goldText.text = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Gold).ToString();
>>>>>>> Stashed changes
    }

}
