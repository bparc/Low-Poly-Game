using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class ItemType : ScriptableObject {
    public Texture2D image;
    public string title = "Unknown";
    public string description;
    public int maxQuantity = 99;
}