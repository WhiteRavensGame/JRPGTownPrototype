using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceAllocateUIManager : Singleton<ResourceAllocateUIManager> {

    [Header("Text Fields")]
    public Text textVillagerInnCount;
    public Text textVillagerItemCount;
    public Text textVillagerWeaponCount;
    public Text textVillagerTavernCount;

    public Text textTotalVillagerCount;

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

    public void BeginDay()
    {

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


}
