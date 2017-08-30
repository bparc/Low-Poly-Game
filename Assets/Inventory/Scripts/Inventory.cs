﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour {
    [Header("Configuration")]
    public int capacity = 16;
    public GameObject slotPrefab;
    public RectTransform grid;
    public RectTransform selection;

    List<InventorySlot> slots = new List<InventorySlot>();

    public void Awake() {
        ChangeCapacity(capacity);
    }

    public void Update() {
        UpdateSelection();
        UpdateCapacity();
    }

    public void UpdateSelection() {
        //TODO(Arc): Clean this function
        InventorySlot previouslySelected = grid.GetChild(0).gameObject.GetComponent<InventorySlot>();

        if (EventSystem.current.currentSelectedGameObject) {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<InventorySlot>()) {
                previouslySelected = EventSystem.current.currentSelectedGameObject.GetComponent<InventorySlot>();
            }
        }

        if (!EventSystem.current.currentSelectedGameObject) {
            EventSystem.current.SetSelectedGameObject(grid.GetChild(0).gameObject); //TODO(Arc): Null check
        }

        if (EventSystem.current.currentSelectedGameObject) {
            if (EventSystem.current.currentSelectedGameObject.transform.parent != grid) {
                EventSystem.current.SetSelectedGameObject(previouslySelected.gameObject); //TODO(Arc): Null check
            }
        }
    }

    public void UpdateCapacity() {
        if (capacity != slots.Count) {
            ChangeCapacity(capacity);
        }
    }

    public void ChangeCapacity(int quantity) {
        foreach (InventorySlot slot in slots) {
            Destroy(slot.gameObject);
        }

        for (int slotIndex = 0; slotIndex < capacity; slotIndex++) {
            slots.Add(Instantiate(slotPrefab, grid.transform).GetComponent<InventorySlot>());
        }
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
