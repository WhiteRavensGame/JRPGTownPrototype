using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class TheEnd : MonoBehaviour
{
    public string menuScene;

    public void LoadMenu()
    {
        File.Delete("Saves/RMsave.doNotOpen");
        SceneManager.LoadScene(menuScene);
    }
}
