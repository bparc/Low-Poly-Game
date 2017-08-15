using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TakingObject: MonoBehaviour {
    public enum eAction { Use, Take };

    public string objectName;
    public eAction action;

    // Use this for initialization
    void Start () {
        objectName = "noname";
    }
	
    public abstract void Activate();
}
