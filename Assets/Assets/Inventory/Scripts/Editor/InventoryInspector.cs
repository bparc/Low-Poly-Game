using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Storage))]
public class InventoryInspector : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        Storage storage = (Storage)target;

        storage.database_ = (ItemsDb)EditorGUILayout.ObjectField(storage.database_, typeof(ItemsDb), true);
        storage.capacity_ = EditorGUILayout.IntField("Capacity", storage.capacity_);
        EditorGUILayout.Separator();
        GUILayout.Label("SLOTS:", EditorStyles.boldLabel);

        for (int index = 0; index < storage.capacity_; index++)
        {          
            GUILayout.Label($"Slot {index}");
            Slot(index);
            EditorGUILayout.Separator();
        }
    }

    void Slot(int index)
    {
        Storage storage = (Storage)target;
              
        //
        if (storage.Has(index))
        {
            Item item;
            storage.Get(index, out item);

            item.class_ = (ItemClass)EditorGUILayout.ObjectField(item.class_, typeof(ItemClass), true);

            if (!item.class_)
            {
                item.quantity_ = 0;
                storage.Remove(index);

                return;
            }

            item.quantity_ = EditorGUILayout.IntSlider(item.quantity_, 1, item.class_.maxStack_);
        }
        else
        {
            ItemClass itemClass = null;

            itemClass = (ItemClass)EditorGUILayout.ObjectField(itemClass, typeof(ItemClass), true);
            EditorGUILayout.IntField("Quantity", 0);

            if (itemClass)
            {
                storage.Add(itemClass, index);
            }
        }
    }
}