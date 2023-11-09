using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManger : MonoBehaviour
{
    public string gameScene;

    public GameObject settingsPanel;
    public GameObject creditsPanel;
    
    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void SettingPanel()
    {
        Debug.Log("Not Yet Implimented");
    }
    public void CreditsPanel()
    {
        Debug.Log("Not Yet Implimented");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
