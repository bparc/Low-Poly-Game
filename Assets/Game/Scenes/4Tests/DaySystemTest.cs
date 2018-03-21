using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystemTest : MonoBehaviour {
    public GameObject sun = null;
    public float speed = 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		sun.transform.Rotate(new Vector3(speed, 0, 0));
	}
}
