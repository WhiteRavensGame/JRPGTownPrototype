using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    [SerializeField]
    private Camera uiCamera;

    private GameLoader loader;
    private TMP_Text tooltipText;
    private RectTransform backgroundRectTransform;

    private void Awake()
    {
        loader = ServiceLocator.Get<GameLoader>();
        loader.CallOnComplete(Initialize);
        
    }
    private void Initialize()
    {
        backgroundRectTransform.Find("Background").GetComponent<RectTransform>();
        tooltipText = transform.Find("UPGRADE COST").GetComponent<TMP_Text>();
    }
    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        transform.localPosition = localPoint;
    }

    private void ShowTooltip(string tooltipString)
    {
        gameObject.SetActive(true);
        tooltipText.text = tooltipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textPaddingSize * 2f, tooltipText.preferredHeight + textPaddingSize * 2f);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }
    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
