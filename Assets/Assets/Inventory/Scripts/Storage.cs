using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Storage : MonoBehaviour, ISerializationCallbackReceiver
{
    public ItemsDb database_;
    public int capacity_ = 10;
    Dictionary<int, Item> items_ = new Dictionary<int, Item>();

    #region DICTIONARY_SERIALIZATION
    public List<int> keys_ = new List<int>();
    public List<Item> values_ = new List<Item>();

    public void OnBeforeSerialize()
    {
        keys_.Clear();
        values_.Clear();

        foreach (var item in items_)
        {
            keys_.Add(item.Key);
            values_.Add(item.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        items_ = new Dictionary<int, Item>();

        for (int i = 0; i != Mathf.Min(keys_.Count, values_.Count); i++)
        {
            items_.Add(keys_[i], values_[i]);
        }
    }
    #endregion

    void Start()
    {

    }

    public bool Move(Storage source, int srcIndex, int dstIndex)
    {
        Item from;
        if (!source.Get(srcIndex, out from))
            return false;

        Item to;
        if (Get(dstIndex, out to))
        {
            bool mergeResult = to.Merge(from);

            if (from.IsEmpty)
                source.items_.Remove(srcIndex);

            return mergeResult;
        }
        else
        {
            items_[dstIndex] = from; source.items_.Remove(srcIndex);

            return true;
        }       
    }

    public bool Move(Storage source)
    {
        bool success = true;

        for (int index = 0; index < source.capacity_; index++)
        {
            Item item;
            if (!source.Get(index, out item))
                continue;

            while (!item.IsEmpty)
            {
                int empty = GetFirstAvailableSlot(item);

                if (empty < 0)
                {
                    success = false;
                    break;
                }

                if (Has(empty))
                {
                    items_[empty].Merge(item);
                }
                else
                {
                    items_[empty] = item.Copy(); item.quantity_ = 0;
                }
            }

            if (item.IsEmpty)
                source.items_.Remove(index);
        }

        return success;
    }

    public int GetFirstAvailableSlot(Item stackable = null)
    {
        if (stackable)
        {
            for (int index = 0; index < capacity_; index++)
            {
                Item item;
                if (Get(index, out item))
                {
                    if (item.CanStack(stackable))
                        return index;
                }
            }
        }

        for (int index = 0; index < capacity_; index++)
        {
            if (!Has(index))
                return index;
        }

        return -1;
    }

    public void Remove(int index)
    {
        Item item;
        if (Get(index, out item))
        {
            item.quantity_--;
    
            if (item.IsEmpty)
                items_.Remove(index);
        }
    }

    public bool Add(ItemClass itemClass, int index)
    {
        if (Has(index))
            return false;

        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.class_ = itemClass;
        newItem.quantity_ = 1;

        items_.Add(index, newItem);

        return true;
    }

    public bool Add(int itemId)
    {
        Item newItem;
        if (!database_.CreateItemFromId(itemId, out newItem))
            return false;

        // try to stack with existing item
        for (int index = 0; index < capacity_; index++)
        {
            Item itemInStorage;
            if (Get(index, out itemInStorage))
                if (itemInStorage.Merge(newItem))
                    return true;
        }

        // otherwise add to the first empty slot
        for (int index = 0; index < capacity_; index++)
        {
            if (!Has(index))
            {
                items_.Add(index, newItem);

                return true;
            }
        }

        // inventory is full!
        return false;
    }
    
    public void Add(int itemId, int quantity)
    {
        for (int i = 0; i < quantity; i++)
            Add(itemId);
    }
    
    public bool Get(int index, out Item item)
    {
        item = null;
    
        if (Has(index))
            item = items_[index];
    
        return item;
    }
    
    public bool Has(int index)
    {
        return items_.ContainsKey(index);
    }

    public bool Has(int id, int quantity)
    {
        ItemClass itemClass = database_.Find(id);
        if (!itemClass)
        {
            Debug.LogWarning("Invalid id: " + id);

            return false;
        }

        int found = 0;

        for (int index = 0; index < capacity_; index++)
        {
            Item item;
            if (Get(index, out item))
            {
                if (item.class_.Equals(itemClass))
                {
                    found += item.quantity_;
                }
            }
        }

        // Debug.Log("found=" + found);

        return found >= quantity;
    }

    public bool Has(ItemClass itemClass, int quantity)
    {
        int found = 0;

        for(int index = 0; index < capacity_; index++)
        {
            Item item;

            if(Get(index, out item))
            {
                if(item.class_.Equals(itemClass))
                {
                    found += item.quantity_;
                }
            }
        }

        return found >= quantity;
    }
}