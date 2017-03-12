using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryWindow_, lootWindow_;

    void Start()
    {
        Close();
    }

    void Update()
    {
        //open/close
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (IsOpen())
            {
                Close();
            }
            else
            {
                Storage storage = null;

                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
                {
                    storage = hit.collider.gameObject.GetComponent<Storage>();
                }

                Open(storage);
            }
        }
    }

    public void Close()
    {
        inventoryWindow_.SetActive(false); lootWindow_.SetActive(false);
    }

    public void Open(Storage loot = null)
    {
        if (IsOpen())
            return;

        inventoryWindow_.SetActive(true);

        if (loot)
        {
            lootWindow_.SetActive(true);

            SlotsPanel lootSlotsPanel = lootWindow_.GetComponentInChildren<SlotsPanel>();
            lootSlotsPanel.storage_ = loot;
            lootSlotsPanel.InstantiateSlots();
        }
    }

    public bool IsOpen()
    {
        return inventoryWindow_.activeInHierarchy;
    }

    public void TakeAll()
    {
        Storage from = lootWindow_.GetComponentInChildren<SlotsPanel>().storage_;
        Storage to = GetComponent<Storage>();

        to.Move(from);
    }
}