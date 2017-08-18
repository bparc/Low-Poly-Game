using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryWindow_, lootWindow_;

    private GameObject userInterface;

    void Start()
    {
        userInterface = GameObject.FindGameObjectWithTag("Interface");

        Close();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            userInterface.GetComponent<ModifyCursor>().isActive = !userInterface.GetComponent<ModifyCursor>().isActive;

            if (IsOpen())
            {
                Close();
            }
            else
            {
                Open();
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