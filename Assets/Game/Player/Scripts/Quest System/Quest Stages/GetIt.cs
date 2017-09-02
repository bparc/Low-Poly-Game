using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetIt : QuestStage{

    [System.Serializable]
     public struct WantedItems{
        public ItemType wantedItem;
        public int quantityItem;
     }

     public WantedItems[] wantedItemsList;
     private Inventory playerInventory;


    private void Start(){
        playerInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    private void Update () {
        foreach(WantedItems item in wantedItemsList){
            if(playerInventory.CheckQuantity(item.wantedItem) < item.quantityItem)
             return;
        }

        isSuccess = true;

        Debug.Log("Items collected!"); //debug
	}
}
