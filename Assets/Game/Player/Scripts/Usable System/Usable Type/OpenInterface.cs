using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Storage))] TODO(Arc): Change
public class OpenInterface: TakingObject {
    //public Storage storage; TODO(Arc): Change

    private Inventory playerInventory;
    private GameObject userInterface;


    public ItemType item; //debug


    void Start (){
        playerInventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        userInterface = GameObject.FindGameObjectWithTag("Interface");

        materialColor = GetComponent<Renderer>().material.color;
    }

    public override void Activate(){
        //playerInventory.GetComponent<InventoryUI>().Open(storage); TODO(Arc): Change
        //userInterface.GetComponent<ModifyCursor>().isActive = !userInterface.GetComponent<ModifyCursor>().isActive;

        switch(action){
            case eAction.Use:
                ///Animation
                
                playerInventory.AddItem(item); //debug
                //if(playerInventory.GetComponentInChildren<Storage>().Move(storage)) TODO(Arc): Change
                
                break;
            case eAction.Take:
                ///Animation

                Destroy(this.gameObject);

                break;
        }
    }
}
