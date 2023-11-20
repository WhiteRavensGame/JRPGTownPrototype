using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSelect : MonoBehaviour
{
    PlayerManager _playerManager = null;

    private void Awake()
    {
        GameLoader loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        _playerManager = ServiceLocator.Get<PlayerManager>();
    }

    public void YesTutorial()
    {
        _playerManager.InTutorial = true;
        SceneManager.LoadScene(2);

    }

    public void NoTutorial()
    {
        SceneManager.LoadScene(2);
    }
}
