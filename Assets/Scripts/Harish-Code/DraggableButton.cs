    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DraggableButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
    private Vector3 originalPosition;


    public void OnBeginDrag(PointerEventData eventData)
    {
    originalPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
    transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
        {

    transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;


    }
    
    }
