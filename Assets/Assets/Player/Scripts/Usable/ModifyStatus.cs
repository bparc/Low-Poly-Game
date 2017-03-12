using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyStatus: TakingObject {

    Status playerStatus;

	void Start () {
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<Status>();
	}

    public override void Activate(){
        playerStatus.modifyStatus(Status.eStatus.Health, -10);

        switch(action){
            case eAction.Use:
                //Animation

             break;
            case eAction.Take:
                //Animation

                Destroy(this.gameObject);
                break;
        }
    }
}
