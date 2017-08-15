using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Storage))]
public class OpenInterface: TakingObject {

    private GameObject userInterface;
    public Storage storage;


    void Start (){
        userInterface = GameObject.FindGameObjectWithTag("Interface");
    }

    public override void Activate(){
        userInterface.GetComponentInChildren<InventoryUI>().Open(storage);

        userInterface.GetComponent<ModifyCursor>().isActive = !userInterface.GetComponent<ModifyCursor>().isActive;


        switch(action){
            case eAction.Use:
                //Animation

             break;
            case eAction.Take:
                //Animation


                if(userInterface.GetComponentInChildren<Storage>().Move(storage))
                 Destroy(this.gameObject);

                break;
        }
    }
}
