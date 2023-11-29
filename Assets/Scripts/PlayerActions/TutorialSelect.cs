using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSelect : MonoBehaviour
{
    static public bool TutorialMode { get; private set; } = false;

    public void YesTutorial()
    {
        TutorialMode = true;
        SceneManager.LoadScene("God Select");

    }

    public void NoTutorial()
    {
        SceneManager.LoadScene("God Select");
    }
}
