using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetIt : QuestStage{
    [System.Serializable]
     public struct WantedItems{
        public ItemClass wantedItem;
        public int quantityItem;
     }

     public WantedItems[] wantedItemsList;

    private Storage playerInventory;


    private void Start(){
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Storage>();
    }

	private void Update () {
        foreach(WantedItems item in wantedItemsList){
            if(!playerInventory.Has(item.wantedItem, item.quantityItem))
             return;
        }

        isSuccess = true;

        Debug.Log("Items collected!"); //debug
	}
}
