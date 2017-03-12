using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystem : MonoBehaviour {

     public Light sunLight;
     public Light moonLight;
     public GameObject stars_ = null;

    public float minutesPerCycle = 1f;

     public float minIntensity = 0f;
     public float maxIntensity = 1f;

     public float minAmbient = 0f;
     public float maxAmbient = 1f;

     public float minFlare = 0f;
     public float maxFlare = 1f;

    private float actualRotate, timeDay;

     private LensFlare sunFlare;

     const float minute = 60;
     const float hour = minute * 60;
     const float all = hour * 24;
     const float halfCycle = 30f;

    const float degreesPerSecond = 360 / all;


	void Start () {
        timeDay = 0f;
        //this.transform.eulerAngles.x = 0f;

        sunFlare = sunLight.GetComponent<LensFlare>();
    }

    private void Update() {
        actualRotate = degreesPerSecond * all / (minutesPerCycle * minute);

        this.transform.Rotate(new Vector3(actualRotate, 0, 0) * Time.deltaTime);
        timeDay += Time.deltaTime / minutesPerCycle;

        if (timeDay >= halfCycle*2) timeDay = 0;

        if (timeDay > 25 && timeDay < halfCycle) { //ZMIERZCH
            if(sunLight.intensity > minIntensity)
             sunLight.intensity -= 0.3f * Time.deltaTime;

            if (RenderSettings.ambientIntensity > minAmbient)
             RenderSettings.ambientIntensity -= 0.3f * Time.deltaTime;

            if(sunFlare.brightness > minFlare && timeDay>28.5)
             sunFlare.brightness -= 1f * Time.deltaTime;        
        }

        else if(timeDay>55 || timeDay < 10) { //SWIT
            if(sunLight.intensity < maxIntensity)
             sunLight.intensity += 0.3f * Time.deltaTime;

            if(RenderSettings.ambientIntensity < maxAmbient)
             RenderSettings.ambientIntensity += 0.3f * Time.deltaTime;

            if(sunFlare.brightness < maxFlare && timeDay < 5)
             sunFlare.brightness += 0.4f * Time.deltaTime;
        }

    }


    private void OnGUI(){ //DEBUG
        System.TimeSpan timeSpan = System.TimeSpan.FromDays(timeDay / 100.0f);

        GUI.Label(new Rect(20, 0, 300, 30), "Czas: " + $"{timeSpan.Hours}:{timeSpan.Minutes}"
            + " ; Intensity: " + sunLight.intensity.ToString("0.0") + " ; Brightness: " + sunFlare.brightness.ToString("0.0"));
    }
}
