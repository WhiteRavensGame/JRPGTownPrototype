using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class TheEnd : MonoBehaviour
{
    public string menuScene;

    public void LoadCredits()
    {
        File.Delete("RMsave.doNotOpen");
        ServiceLocator.Get<GameLoader>().Exit();
        SceneManager.LoadScene(menuScene);
    }

    public void LoadMenu()
    {
        File.Delete("RMsave.doNotOpen");
        SceneManager.LoadScene(menuScene);
    }
}
