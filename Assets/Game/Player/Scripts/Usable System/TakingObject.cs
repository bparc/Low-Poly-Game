using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TakingObject: MonoBehaviour {
    public enum eAction { Use, Take };

     public string objectName;
     public eAction action;

    [HideInInspector]
     public Color materialColor;


    void Start () {
        materialColor = GetComponent<Renderer>().material.color;
    }
	
    public abstract void Activate();
}
