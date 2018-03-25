using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesAnimations : MonoBehaviour {
    public Transform rotatedObject;
    public float speed = 0.03f;

    private float i = 0f;

	void Start () {
        if (rotatedObject == null)
            rotatedObject = this.transform;
	}
	
	void Update () {
           rotatedObject.Rotate(new Vector3(Mathf.Cos(i += speed) * Time.deltaTime, 0, 0));
	}
}
