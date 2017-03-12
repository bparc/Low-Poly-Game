using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDb : MonoBehaviour
{
    public string directory_ = "Items";
    Dictionary<int, ItemClass> database_ = new Dictionary<int, ItemClass>();

    void Awake()
    {
        Refresh();
    }

    public void Refresh()
    {
        database_.Clear();

        ItemClass[] itemClasses = Resources.LoadAll<ItemClass>(directory_);

        int id = 0;

        foreach (ItemClass itemClass in itemClasses)
        {
            itemClass.name_ = itemClass.name;
            database_.Add(id++, itemClass);
        }
    }

    public bool CreateItemFromId(int id, out Item item)
    {
        item = null;

        if (!database_.ContainsKey(id))
            return false;

        item = ScriptableObject.CreateInstance<Item>();
        item.class_ = database_[id];
        item.quantity_ = 1;

        return true;
    }
}
