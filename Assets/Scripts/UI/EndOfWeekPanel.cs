using UnityEngine;
using TMPro;
using Mono.Cecil;

public class EndOfWeekPanel : MonoBehaviour
{
    [SerializeField] GameObject _mainCanvas;
    [SerializeField] private TextMeshProUGUI villagersCount;
    [SerializeField] private TextMeshProUGUI villagersMoral;

    public void Initialize()
    {
        UpdateVillagersNums();
    }

    public void EndWeek()
    {
        ServiceLocator.Get<PlayerManager>().gameState = GameStates.MainScreen;
        this.gameObject.SetActive(false);
        _mainCanvas.SetActive(true);
        ServiceLocator.Get<EventManager>().CheckEvent();
        ServiceLocator.Get<VillageManager>().InstantiateVillagers();
    }

    public void UpdateVillagersNums()
    {
        villagersCount.text = ServiceLocator.Get<VillageManager>().GetVillagersAmt();
        villagersMoral.text = ServiceLocator.Get<ResourceManager>().GetResourceAmt(Resources.Moral) + "%";
    }
}
