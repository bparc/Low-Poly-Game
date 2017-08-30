using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DescriptionWindow : MonoBehaviour {
    public Text title;
    public Text description;

	void Update () {
        if (!EventSystem.current.currentSelectedGameObject) {
            return;
        }

        InventorySlot selectedSlot = EventSystem.current.currentSelectedGameObject.GetComponent<InventorySlot>();

        if (!selectedSlot) {
            return;
        }

        ItemType itemType = selectedSlot.Type;

        if (itemType) {
            title.text = itemType.title;
            description.text = itemType.description;
        } else {
            title.text = string.Empty;
            description.text = string.Empty;
        }
	}
}
