using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelBuildingUIManager : Singleton<LevelBuildingUIManager> {

    public GameObject levelBuildingLayer;

    public Text textInnLevel;
    public Text textItemLevel;
    public Text textWeaponLevel;

    public Text textInnUpgradeButton;
    public Text textItemUpgradeButton;
    public Text textWeaponUpgradeButton;

    public Text textPlayerGold;

    public void ShowLevelBuildingUIManager(bool show)
    {
        levelBuildingLayer.SetActive(show);
        if (show)
        {
            UpdateTextDescriptions();
        }
    }

    private void UpdateTextDescriptions()
    {
        textInnLevel.text = "Inn Lv: " + GameManager.Instance.playerStats.levelInn;
        textItemLevel.text = "Item Lv: " + GameManager.Instance.playerStats.levelItem;
        textWeaponLevel.text = "Weapon Lv: " + GameManager.Instance.playerStats.levelWeapon;

        if (GameManager.Instance.playerStats.levelInn <= 5)
            textInnUpgradeButton.text = "Upgrade (" + GameManager.Instance.levelInnCost[GameManager.Instance.playerStats.levelInn - 1] + ")";
        else
            textInnUpgradeButton.text = "Fully Upgraded";

        if (GameManager.Instance.playerStats.levelItem <= 5)
            textItemUpgradeButton.text = "Upgrade (" + GameManager.Instance.levelInnCost[GameManager.Instance.playerStats.levelItem - 1] + ")";
        else
            textItemUpgradeButton.text = "Fully Upgraded";

        if (GameManager.Instance.playerStats.levelWeapon <= 5)
            textWeaponUpgradeButton.text = "Upgrade (" + GameManager.Instance.levelInnCost[GameManager.Instance.playerStats.levelWeapon - 1] + ")";
        else
            textWeaponUpgradeButton.text = "Fully Upgraded";

        textPlayerGold.text = GameManager.Instance.playerStats.gold.ToString() + " G";
    }

    public void UpgradeInn()
    {
        int level = GameManager.Instance.playerStats.levelInn;
        int cost = GameManager.Instance.levelInnCost[GameManager.Instance.playerStats.levelInn - 1];

        if (cost <= GameManager.Instance.playerStats.gold)
        {
            GameManager.Instance.playerStats.gold -= cost;
            GameManager.Instance.playerStats.levelInn += 1;
            UpdateTextDescriptions();
        }
     
    }

    public void UpgradeItemShop()
    {
        int level = GameManager.Instance.playerStats.levelItem;
        int cost = GameManager.Instance.levelItemShopCost[GameManager.Instance.playerStats.levelItem - 1];

        if (cost <= GameManager.Instance.playerStats.gold)
        {
            GameManager.Instance.playerStats.gold -= cost;
            GameManager.Instance.playerStats.levelItem += 1;
            UpdateTextDescriptions();
        }
    }

    public void UpgradeWeaponShop()
    {
        int level = GameManager.Instance.playerStats.levelWeapon;
        int cost = GameManager.Instance.levelWeaponShopCost[GameManager.Instance.playerStats.levelWeapon - 1];

        if (cost <= GameManager.Instance.playerStats.gold)
        {
            GameManager.Instance.playerStats.gold -= cost;
            GameManager.Instance.playerStats.levelWeapon += 1;
            UpdateTextDescriptions();
        }


    }

    public void EndDayButtonClicked()
    {
        ShowLevelBuildingUIManager(false);
       GameManager.Instance.LoadNextGameEvent();
    }


}
