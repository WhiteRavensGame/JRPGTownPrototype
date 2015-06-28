using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProfitsScreenManager : Singleton<ProfitsScreenManager> {

    public GameObject profitsLayer;
    [Header("Texts")]
    public Text textInnProfits;
    public Text textItemProfits;
    public Text textWeaponProfits;

    public void ShowProfitsScreen(bool show)
    {
        profitsLayer.SetActive(show);
        if (show)
        {
            textInnProfits.text = "Inn: " + GameManager.Instance.playerStats.levelInn;
            textItemProfits.text = "Item: " + GameManager.Instance.playerStats.levelItem;
            textWeaponProfits.text = "Weapon: " + GameManager.Instance.playerStats.levelWeapon;
        }
    }
}
