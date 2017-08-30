using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    public RawImage image;
    public Text quantityText;

    ItemType type;
    int quantity;

    public bool IsEmpty { get { return !type || quantity <= 0; } }
    public ItemType Type { get { return type; } }
    public int Quantity { get { return quantity; } }

    public bool CanAdd(ItemType type) {
        if (IsEmpty) {
            return true;
        }

        if (this.type) {
            if (this.type.Equals(type) && quantity < this.type.maxQuantity) {
                return true;
            }
        }

        return false;
    }

    public bool AddItem(ItemType type) {
        if (!CanAdd(type)) {
            return false;
        }

        this.type = type;
        quantity++;

        UpdateImage();

        return true;
    }

    public void RemoveItem() {
        type = null;
        quantity = 0;

        UpdateImage();
    }

    public void DecreaseItem() {
        quantity--;

        if (quantity <= 0) {
            RemoveItem();
        }

        UpdateImage();
    }

    public void UpdateImage() {
        if (type) {
            image.texture = type.image;
            image.color = Color.white;

            if (quantity > 1) {
                quantityText.text = quantity.ToString();
            } else {
                quantityText.text = string.Empty;
            }
        } else {
            image.texture = null;
            image.color = Color.clear;
            quantityText.text = string.Empty;
        }
    }
}
