using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemClass : ScriptableObject
{
    public int maxStack_ = 10;
    [HideInInspector]
    public string name_;
    public Texture2D image_;

    [MenuItem("Assets/Create/Items/Item")]
    public static void CreateAsset()
    {
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<ItemClass>(), "Assets/Inventory System/Resources/Items/New Item.asset");
    }
}