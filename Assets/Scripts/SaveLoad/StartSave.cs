using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSave : MonoBehaviour
{
    public void SaveButton()
    {
        var newData = ServiceLocator.Get<SaveSystem>().Load<ResourceManager.SaveResources>("RMsave.doNotOpen");
        if (!EqualityComparer<ResourceManager.SaveResources>.Default.Equals(newData, default))
        {
            SceneManager.LoadScene("God Select");
            ServiceLocator.Get<GameManager>().LoadGame = true;
        }
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("Tutorial Activate");
    }

    public void QuitGame()
    {
        // This function will be called when the button is clicked
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
