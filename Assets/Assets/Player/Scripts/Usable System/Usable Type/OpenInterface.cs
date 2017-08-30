using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Storage))]
public class OpenInterface: TakingObject {

    public Storage storage;

    private GameObject playerInventory;
    private GameObject userInterface;


    void Start (){
        playerInventory = GameObject.FindGameObjectWithTag("Inventory");
        userInterface = GameObject.FindGameObjectWithTag("Interface");

        materialColor = GetComponent<Renderer>().material.color;
    }

    public override void Activate(){
        playerInventory.GetComponent<InventoryUI>().Open(storage);

        userInterface.GetComponent<ModifyCursor>().isActive = !userInterface.GetComponent<ModifyCursor>().isActive;


        switch(action){
            case eAction.Use:
                //Animation

             break;
            case eAction.Take:
                //Animation


                if(playerInventory.GetComponentInChildren<Storage>().Move(storage))
                 Destroy(this.gameObject);

                break;
        }
    }
}
