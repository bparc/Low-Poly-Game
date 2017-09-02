using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyStatus: TakingObject {

    private Status playerStatus;

    public int health;
    public int mana;
    public int stamina;


    void Start () {
        playerStatus = GameObject.FindGameObjectWithTag("Character").GetComponent<Status>();

        materialColor = GetComponent<Renderer>().material.color;
	}

    public override void Activate(){
        playerStatus.modifyStatus(Status.eStatus.Health, health);
        playerStatus.modifyStatus(Status.eStatus.Mana, mana);
        playerStatus.modifyStatus(Status.eStatus.Stamina, stamina);

        switch (action){
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
