using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryTest : MonoBehaviour {
    public Inventory inventory;
    public ItemType itemToAdd;
    public ModifyCursor modifyCursor;
    public Canvas menu;

    public bool test;

	void Update () {
        ReadInput();
	}

    public void ReadInput() {
        GameObject currentlySelected = EventSystem.current.currentSelectedGameObject;

        if (currentlySelected) {
            InventorySlot selectedSlot = EventSystem.current.currentSelectedGameObject.GetComponent<InventorySlot>();

            if (selectedSlot) {
                if (Input.GetKeyDown(KeyCode.R)) {
                    selectedSlot.RemoveItem();
                }

                if (Input.GetKeyDown(KeyCode.F)) {
                    selectedSlot.DecreaseItem();
                }

                if (Input.GetKeyDown(KeyCode.Q)) {
                    if (!selectedSlot.IsEmpty) {
                        Debug.Log(inventory.CheckQuantity(selectedSlot.Type));
                    }
                }

                if (Input.GetKeyDown(KeyCode.T)) {
                    inventory.AddItem(itemToAdd);
                }

                if (Input.GetKeyDown(KeyCode.Y)) {
                    selectedSlot.AddItem(itemToAdd);
                }

                if (Input.GetKeyDown(KeyCode.U)) {
                    int amount = selectedSlot.AddItem(itemToAdd, 4);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab)) {
            if(menu.enabled)
            {
                menu.enabled = false;
                modifyCursor.isActive = true;
            }
            else
            {
                menu.enabled = true;
                modifyCursor.isActive = false;
            }
        }
    }
}
