using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Storage))] TODO(Arc): Change
public class OpenInterface: TakingObject {

    //public Storage storage; TODO(Arc): Change

    private GameObject playerInventory;
    private GameObject userInterface;


    void Start (){
        playerInventory = GameObject.FindGameObjectWithTag("Inventory");
        userInterface = GameObject.FindGameObjectWithTag("Interface");
    }

    public override void Activate(){
        //playerInventory.GetComponent<InventoryUI>().Open(storage); TODO(Arc): Change

         userInterface.GetComponent<ModifyCursor>().isActive = !userInterface.GetComponent<ModifyCursor>().isActive;

        switch(action){
            case eAction.Use:
                //Animation

             break;
            case eAction.Take:
                //Animation


                //if(playerInventory.GetComponentInChildren<Storage>().Move(storage)) TODO(Arc): Change
                // Destroy(this.gameObject);

                break;
        }
    }
}
