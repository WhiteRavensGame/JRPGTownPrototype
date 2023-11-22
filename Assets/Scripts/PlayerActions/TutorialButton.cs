using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    [SerializeField] private Button _current;
    [SerializeField] private GameObject _next;

    private void Awake()
    {
        ServiceLocator.Get<GameLoader>().CallOnComplete(Initialize);
    }

    private void Initialize()
    {
        if (_next != null)
        {
            _current.onClick.AddListener(NextButton);
        }
    }

    private void NextButton()
    {
        _next.SetActive(true);
        gameObject.SetActive(false);
    }
}
