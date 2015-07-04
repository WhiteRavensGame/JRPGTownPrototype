using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class ResourceAllocateUIManager : Singleton<ResourceAllocateUIManager> {

    [Header("Main Layer")]
    public GameObject resourceAllocationLayer;

    [Header("Text Fields")]
    public Text textVillagerInnCount;
    public Text textVillagerItemCount;
    public Text textVillagerWeaponCount;
    public Text textVillagerTavernCount;

    public Text textTotalVillagerCount;
    public Text textDayNumber;

    private int villagersInn = 0;
    private int villagersItemShop = 0;
    private int villagersWeaponShop = 0;
    private int villagersTavern = 0;

    private int villagersTotalCount = 25;

	// Use this for initialization
	void Start () {
        UpdateVillagersText();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowResourceAllocateScreen(bool show)
    {
        resourceAllocationLayer.SetActive(show);
        if (show)
        {
            villagersTotalCount = GameManager.Instance.playerStats.villagersCount;
            textDayNumber.text = "Day " +  GameManager.Instance.playerStats.dayCount.ToString();
            UpdateVillagersText();
        }
        else
        {

        }
    }

    public void AddInnVillagers(int count)
    {
        villagersInn += count;
        UpdateVillagersText();
    }

    public void AddItemVillagers(int count)
    {
        villagersItemShop += count;
        UpdateVillagersText();
    }

    public void AddWeaponVillagers(int count)
    {
        villagersWeaponShop += count;
        UpdateVillagersText();
    }

    public void AddTavernVillagers(int count)
    {
        villagersTavern += count;
        UpdateVillagersText();
    }

    public void ContinueButtonPressed()
    {
        Debug.Log("DAY START (for now)!");

        //TEMPORARY!
        int innCustomers = 20;
        int itemCustomers = 8;
        int weaponCustomers = 5;

        //Player gets enough coins.
        int dayEarnings = DayManager.Instance.CalculateDailyEarnings(villagersInn, villagersItemShop, villagersWeaponShop, innCustomers, itemCustomers, weaponCustomers);
        GameManager.Instance.playerStats.gold += dayEarnings;

        ShowResourceAllocateScreen(false);
        ProfitsScreenManager.Instance.ShowProfitsScreen(true);
    }

    private void UpdateVillagersText()
    {
        textVillagerInnCount.text = villagersInn.ToString();
        textVillagerItemCount.text = villagersItemShop.ToString();
        textVillagerWeaponCount.text = villagersWeaponShop.ToString();
        //textVillagerTavernCount.text = textVillagerTavernCount.ToString();
        textTotalVillagerCount.text = "Villagers: " + GetVillagersLeft() + "/" + villagersTotalCount;
    }

    private int GetVillagersLeft()
    {
        return (villagersTotalCount - villagersInn - villagersItemShop - villagersWeaponShop - villagersTavern);
    }

    public void StartTestConversation()
    {
        //THIS IS A TEST. DELETE WHEN DONE.
        DialogueManager.StartConversation("Recette");
    }


}
