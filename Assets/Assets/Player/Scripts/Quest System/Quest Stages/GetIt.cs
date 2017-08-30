using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetIt : QuestStage{

    [System.Serializable]
     public struct WantedItems{
        //public ItemClass wantedItem; TODO(Arc): Change
        public int quantityItem;
     }

     public WantedItems[] wantedItemsList;
     //private Storage playerInventory; TODO(Arc): Change


    private void Start(){
        //playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Storage>(); TODO(Arc): Change
    }

    private void Update () {
        foreach(WantedItems item in wantedItemsList){
            // if(!playerInventory.Has(item.wantedItem, item.quantityItem)) TODO(Arc): Change
            //  return;
        }

        isSuccess = true;

        Debug.Log("Items collected!"); //debug
	}
}
