using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemType : ScriptableObject {
    public Texture2D image;
    public string title = "Unknown";
    public string description;
    public int maxQuantity = 99;

    [MenuItem("Assets/Create/Items/Item")]
    public static void CreateAsset() {
        string path = "Assets/Game/Items/New Item.asset"; //TODO(Arc): Generate unique asset path for currently selected folder.

        //AssetDatabase.GenerateUniqueAssetPath(string.Empty);

        AssetDatabase.CreateAsset(CreateInstance<ItemType>(), path);
    }
}