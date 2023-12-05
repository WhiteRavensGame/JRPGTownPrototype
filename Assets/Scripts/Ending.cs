using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public GameObject playerOutcomePopUp;

    public List<GameObject> popUps;
    public GameObject button;
    public int index = 0;

    public void NextCharEnding()
    {
        if (index >= popUps.Count - 1)
        {
            popUps[index].SetActive(false);
            playerOutcomePopUp.SetActive(true);
            button.gameObject.SetActive(false);
            return;
        }
        popUps[index++].SetActive(false);
        popUps[index].SetActive(true);
        
    }

    public void Continue()
    {
        SceneManager.LoadScene("DecisionScreen");
    }

    public void Decision()
    {
        SceneManager.LoadScene("CharacterEnding");
    }
    public void Next()
    {
        SceneManager.LoadScene("Ending");
    }
}
