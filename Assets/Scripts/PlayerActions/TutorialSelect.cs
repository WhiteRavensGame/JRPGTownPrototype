using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSelect : MonoBehaviour
{
    static public bool TutorialMode { get; private set; } = false;

    public void YesTutorial()
    {
        TutorialMode = true;
        SceneManager.LoadScene(2);

    }

    public void NoTutorial()
    {
        SceneManager.LoadScene(2);
    }
}
