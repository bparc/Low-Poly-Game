using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Experimental script

public class TreesAnimationsMoreObjects : MonoBehaviour {
    public List<Transform> rotatedObjects;
    public float speed = 0.03f;

    private List<float> currentTilt = new List<float>();

	void Start () {
        if (rotatedObjects.Count == 0)
            rotatedObjects.Add(this.transform);

        for(int i = 0; i < rotatedObjects.Count; ++i)
            currentTilt.Add(0f);
	}
	
	void Update () {
        for(int i = 0; i < rotatedObjects.Count; ++i) {
            rotatedObjects[i].Rotate(new Vector3(Mathf.Cos(currentTilt[i] += speed) * Time.deltaTime, 0, 0));
        }
	}
}