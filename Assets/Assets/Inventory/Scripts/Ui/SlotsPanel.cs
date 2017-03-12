using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsPanel : MonoBehaviour
{
    int count;
    public Storage storage_;
    public GameObject slotPrefab_;
    public Canvas canvas_;

    List<GameObject> slots = new List<GameObject>();

    void Start()
    {      
        InstantiateSlots();
    }

    public void InstantiateSlots()
    {
        if (storage_)
        {
            count = storage_.capacity_;

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            slots.Clear();

            for (int id = 0; id < count; id++)
            {
                slots.Add(Instantiate(slotPrefab_));
                slots[id].GetComponent<DraggableSlot>().id_ = id;
                slots[id].GetComponent<DraggableSlot>().parentPanel_ = this;
                slots[id].GetComponent<DraggableSlot>().canvas_ = canvas_;
                slots[id].transform.SetParent(transform);
            }
        }
    }
}