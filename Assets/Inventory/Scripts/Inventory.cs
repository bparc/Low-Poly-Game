using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class Inventory : MonoBehaviour {
    [Header("Configuration")]
    //public int capacity = 16;
    public Vector2 capacity;
    public GameObject slotPrefab;
    public RectTransform window;
    public RectTransform selection;
    public GridLayoutGroup grid;
    
    List<InventorySlot> slots = new List<InventorySlot>();

    public void Awake() {
        
        ChangeCapacity((int)capacity.x * (int)capacity.y);

        //
        EventSystem.current.SetSelectedGameObject(grid.gameObject.transform.GetChild(0).gameObject);
        //
    }

    public void Update() {
        //UpdateSelection();
        UpdateCapacity();
    }

    void UpdateSelection() {
        GameObject currentlySelected = EventSystem.current.currentSelectedGameObject;

        if (!currentlySelected) {
            EventSystem.current.SetSelectedGameObject(grid.transform.GetChild(0).gameObject);
        }
        else {
            if (currentlySelected.transform.parent != grid) {
                EventSystem.current.SetSelectedGameObject(grid.transform.GetChild(0).gameObject);
            }
        }
    }

    void UpdateCapacity() {
        //if (capacity != slots.Count) {
        //    ChangeCapacity(capacity);
        //}
    }

    Vector2 ComputePadding() {
        RectTransform gridTransform = grid.gameObject.GetComponent<RectTransform>();
        return new Vector2(gridTransform.offsetMin.x + -gridTransform.offsetMax.x,
            gridTransform.offsetMin.y + -gridTransform.offsetMax.y);
        
    }

    void ComputeWindowSize() {
        Vector2 size = new Vector2(grid.cellSize.x * capacity.x, grid.cellSize.y * capacity.y);
        Vector2 spacing = new Vector2(capacity.x * grid.spacing.x - grid.spacing.x, capacity.y * grid.spacing.y - grid.spacing.y);
        Vector2 padding = ComputePadding();

        window.sizeDelta = size + spacing + padding;
    }

    public void ChangeCapacity(int quantity) {
        foreach (InventorySlot slot in slots) {
            Destroy(slot.gameObject);
        }

        for (int slotIndex = 0; slotIndex < (int)capacity.x * (int)capacity.y; slotIndex++) {
            slots.Add(Instantiate(slotPrefab, grid.transform).GetComponent<InventorySlot>());
        }

        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = (int)capacity.x;

        ComputeWindowSize();
    }

    public bool AddItem(ItemType type) {
        foreach(InventorySlot slot in slots) {
            if (slot.AddItem(type)) {
                return true;
            }
        }

        //TODO(Arc): Message logging
        Debug.Log("Your inventory is full!");

        return false;
    }

    public int CheckQuantity(ItemType type) {
        int quantity = 0;

        foreach (InventorySlot slot in slots) {
            if (!slot.IsEmpty) {
                if (slot.Type.Equals(type)) {
                    quantity += slot.Quantity;
                }
            }
        }

        return quantity;
    }
}
