using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NonPlayerCharacter))]
public class StartTalking : TakingObject {
    //eAction action;

    private NonPlayerCharacter scriptNPC;

	void Start () {
		scriptNPC = this.GetComponent<NonPlayerCharacter>();

        materialColor = GetComponent<Renderer>().material.color;
	}
	
	public override void Activate(){
        if(scriptNPC != null)
         scriptNPC.startTalking();
    }
}
