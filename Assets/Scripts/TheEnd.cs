using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public string menuScene;

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
