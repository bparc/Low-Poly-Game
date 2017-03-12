using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public ItemClass class_;
    public int quantity_;
    public bool IsEmpty { get { return quantity_ <= 0; } }

    public Item Copy()
    {
        return (Item)MemberwiseClone();
    }

    public bool CanStack(Item item)
    {
        return class_.Equals(item.class_) && quantity_ < class_.maxStack_ && item != this;
    }

    public bool Merge(Item item)
    {
        if (!CanStack(item))
            return false;

        int total = quantity_ + item.quantity_;

        if (total < class_.maxStack_)
        {
            quantity_ = total; item.quantity_ = 0;
        }
        else
        {
            quantity_ = class_.maxStack_; item.quantity_ = total - class_.maxStack_;
        }

        return true;
    }
}