using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject lorrainePopUp;
    public GameObject roePopUp;
    public GameObject oscarPopUp;
    public GameObject willPopUp;
    public GameObject adelainePopUp;

    public GameObject lorraineButton;
    public GameObject roeButton;
    public GameObject oscarButton;
    public GameObject willButton;
    public GameObject adelaineButton;
    public void Continue()
    {
        SceneManager.LoadScene("DecisionScreen");
    }

    public void Decision()
    {
        SceneManager.LoadScene("CharacterEnding");
    }

    public void LorraineToRoe()
    {
        lorrainePopUp.SetActive(false);
        roePopUp.SetActive(true);
        lorraineButton.SetActive(false);
        roeButton.SetActive(true);
    }

    public void RoeToOscar()
    {
        roePopUp.SetActive(false);
        oscarPopUp.SetActive(true);
        roeButton.SetActive(false);
        oscarButton.SetActive(true);
    }

    public void OscarToWill()
    {
        oscarPopUp.SetActive(false);
        willPopUp.SetActive(true);
        oscarButton.SetActive(false);
        willButton.SetActive(true);
    }

    public void WillToAdelaine()
    {
        willPopUp.SetActive(false);
        adelainePopUp.SetActive(true);
        willButton.SetActive(false);
        adelaineButton.SetActive(true);
    }

    public void AdelaineToEnding()
    {
        
        SceneManager.LoadScene("Ending");
    }
}
