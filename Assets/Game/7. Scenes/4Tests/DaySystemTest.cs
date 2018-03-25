using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystemTest : MonoBehaviour {
    public GameObject sun = null;
    public float speed = 0.2f;
    public float speedSetting = 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log($"{sun.transform.rotation.x} | {RenderSettings.ambientIntensity}");
        Debug.Log($"{sun.transform.localEulerAngles.x} | {RenderSettings.ambientIntensity}");

        if(sun.transform.eulerAngles.x >= 360)
            sun.transform.eulerAngles.Set(0, 0, 0);
            //sun.transform.rotation.Set(0, 0, 0, 0);

		sun.transform.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));

        if (sun.transform.eulerAngles.x > 180) {
            if (RenderSettings.ambientIntensity > 0)
                RenderSettings.ambientIntensity -= speedSetting * Time.deltaTime;
        }

        else if (sun.transform.eulerAngles.x > 0) {
            if (RenderSettings.ambientIntensity < 1f)
                RenderSettings.ambientIntensity += speedSetting * Time.deltaTime;
        }
	}
}
