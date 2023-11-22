using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public enum Type
    {
        ON_LOAD,
        ON_CLICK
    }

    [SerializeField] private Type _tutorialType;
    [SerializeField] private GameObject _firstScreen;
    [SerializeField] private Button _finalScreen;
    private PlayerManager _playerManager;

    private void Awake()
    {
        ServiceLocator.Get<GameLoader>().CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        _finalScreen.onClick.AddListener(EndTutorial);
        _playerManager = ServiceLocator.Get<PlayerManager>();

        if (_tutorialType == Type.ON_LOAD)
        {
            ActivateTutorial();
        }
    }

    public void ActivateTutorial()
    {
        if (TutorialSelect.TutorialMode)
        {
            _playerManager.InTutorial = true;
            _firstScreen.gameObject.SetActive(true);
        }
    }

    private void EndTutorial()
    {
        _playerManager.InTutorial = false;
        _finalScreen.gameObject.SetActive(false);
    }
}
