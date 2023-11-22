using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

public class VillagerUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _canvas;

    [SerializeField] private InputAction mousePos;

    private void OnEnable()
    {
        mousePos.Enable();
    }

    private void OnDisable()
    {
        mousePos.Disable();   
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(_canvas);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = mousePos.ReadValue<Vector2>();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {
            if(result.gameObject.tag == "WorkerSlot")
            {
                _parent = result.gameObject.transform;
                transform.SetParent(_parent);
                return;
            }
        }

        transform.SetParent(_parent);
    }
}
