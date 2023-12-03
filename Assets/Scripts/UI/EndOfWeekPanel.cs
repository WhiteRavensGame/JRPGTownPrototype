using UnityEngine;
using TMPro;
using Mono.Cecil;

public class EndOfWeekPanel : MonoBehaviour
{
    private bool initialized = false;
    [SerializeField] GameObject _mainCanvas;
    [SerializeField] private TextMeshProUGUI _villagersCount;
    [SerializeField] private TextMeshProUGUI _villagersMoral;
    [SerializeField] private TextMeshProUGUI _silkText;
    [SerializeField] private TextMeshProUGUI _fishText;
    [SerializeField] private TextMeshProUGUI _ironText;
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private TextMeshProUGUI _troopsText;

    public void Initialize()
    {
        UpdateVillagersNums();
        UpdateResources();
        ServiceLocator.Get<PlayerManager>().AllocatingVillagers = true;
        initialized = true;
    }

    private void OnEnable()
    {
        if (initialized)
        {
            UpdateVillagersNums();
            UpdateResources();
            ServiceLocator.Get<PlayerManager>().AllocatingVillagers = true;
        }
    }

    public void EndWeek()
    {
        ServiceLocator.Get<PlayerManager>().AllocatingVillagers = false;
        ServiceLocator.Get<PlayerManager>().gameState = GameStates.MainScreen;
        this.gameObject.SetActive(false);
        _mainCanvas.SetActive(true);
        ServiceLocator.Get<EventManager>().CheckEvent();
        ServiceLocator.Get<VillageManager>().InstantiateVillagers();
    }

    public void UpdateVillagersNums()
    {
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
    }
}
