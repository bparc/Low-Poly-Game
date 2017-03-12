using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableSlot : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    public Canvas canvas_;
    public RawImage item_;
    public Text counter_;
    public Text name_; 
    public int id_ = -1;
    public SlotsPanel parentPanel_;

    GameObject draggedIcon_;

    void SetImageAndCounterValue()
    {
        if (!parentPanel_)
            return;

        if (!parentPanel_.storage_)
            return;

        Item item;
        parentPanel_.storage_.Get(id_, out item);

        item_.texture = item ? item.class_.image_ : null;
        item_.color = item_.texture ? draggedIcon_ ? new Color(1.0f, 1.0f, 1.0f, 0.4f) : Color.white : new Color();
        counter_.text = item ? $"x{item.quantity_}" : string.Empty;

        if (name_)
        {
            name_.text = item ? item.class_.name_ : string.Empty;
        }
    }

    void AssignId()
    {
        foreach (Transform child in transform.parent)
        {
            id_++;

            if (child == transform)
                return;
        }

        id_ = -1;
    }

    // MonoBehaviour
    void Start()
    {
        //AssignId();
    }

    void Update()
    {
        SetImageAndCounterValue();
    }

    void OnDisable()
    {
        if (draggedIcon_)
            Destroy(draggedIcon_);
    }

    // Event Handlers
    public void OnBeginDrag(PointerEventData data)
    {
        if (!parentPanel_.storage_)
            return;

        if (data.button != PointerEventData.InputButton.Left || !canvas_)
            return;

        Item item;
        if (!parentPanel_.storage_.Get(id_, out item))
            return;

        draggedIcon_ = new GameObject("Icon");

        draggedIcon_.transform.SetParent(canvas_.transform);
        draggedIcon_.transform.SetAsLastSibling();

        draggedIcon_.AddComponent<RawImage>().texture = item.class_.image_;
        draggedIcon_.GetComponent<RawImage>().rectTransform.sizeDelta = new Vector2(50.0f, 50.0f);

        draggedIcon_.AddComponent<CanvasGroup>().blocksRaycasts = false;

        draggedIcon_.transform.position = data.position;
    }

    public void OnDrag(PointerEventData data)
    {
        if (draggedIcon_)
            draggedIcon_.transform.position = data.position;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (draggedIcon_)
            Destroy(draggedIcon_);
    }

    public void OnDrop(PointerEventData data)
    {
        if (!parentPanel_.storage_)
            return;

        if (data.button != PointerEventData.InputButton.Left)
            return;

        DraggableSlot droppedSlot = data.pointerDrag.GetComponent<DraggableSlot>();

        if (!droppedSlot)
            return;
        if (!droppedSlot.draggedIcon_)
            return;

        parentPanel_.storage_.Move(droppedSlot.parentPanel_.storage_, droppedSlot.id_, id_);        
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (!parentPanel_.storage_)
            return;

        if (draggedIcon_)
            return;

        if (data.button == PointerEventData.InputButton.Left)
            parentPanel_.storage_.Remove(id_);
    }
}