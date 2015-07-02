using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProfitsScreenManager : Singleton<ProfitsScreenManager> {

    public GameObject profitsLayer;
    [Header("Texts")]
    public Text textInnProfits;
    public Text textItemProfits;
    public Text textWeaponProfits;
    public Text textTotalProfits;

    public void ShowProfitsScreen(bool show)
    {
        profitsLayer.SetActive(show);
        if (show)
        {
            textInnProfits.text = "Inn Lv" + GameManager.Instance.playerStats.levelInn + " :" + DayManager.Instance.innEarnings;
            textItemProfits.text = "Item Lv: " + GameManager.Instance.playerStats.levelItem + " :" + DayManager.Instance.itemEarnings;
            textWeaponProfits.text = "Weapon Lv: " + GameManager.Instance.playerStats.levelWeapon + " :" + DayManager.Instance.weaponEarnings;

            textTotalProfits.text =DayManager.Instance.totalEarnings.ToString();
        }
    }

    public void ContinueButtonPressed()
    {
        ShowProfitsScreen(false);
        
        EventScreenUIManager.Instance.ShowEventScreen(true, GameManager.Instance.playerStats.dayCount);
    }
    
}
