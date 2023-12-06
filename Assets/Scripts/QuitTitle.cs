using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitTitle : MonoBehaviour
{
    public void OptionsButton()
    {
        SceneManager.LoadScene("SaveScene");
    }
}