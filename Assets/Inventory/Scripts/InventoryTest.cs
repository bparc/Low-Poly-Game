using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryTest : MonoBehaviour {
    public Inventory inventory;
    public ItemType itemToAdd;
    public ModifyCursor modifyCursor;

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

                    Debug.Log("AddItem()");
                }

                if (Input.GetKeyDown(KeyCode.Y)) {
                    selectedSlot.AddItem(itemToAdd);

                    Debug.Log("AddItem()");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab)) {
            modifyCursor.isActive = !modifyCursor.isActive;
            Debug.Log("GetKeyDown()");
        }
    }
}
