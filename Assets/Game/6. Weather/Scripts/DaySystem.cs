using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystem : MonoBehaviour {
    public Material skyboxDay;
    public Material skyboxNight;

    public Light sunLight;

    [Header("Velocity")]
    public float minutesPerCycle = 1f;
    public float speedIntensity = 0.2f;

    [Header("Min-Max Settings")]
    public float minIntensity = 0f;
    public float maxIntensity = 1f;

    public float minAmbient = 0f;
    public float maxAmbient = 1f;


    private float actualRotate, timeDay = 0f;

    const float allSecondsInDay = (60 * 60 * 24);
    const float degreesPerSecond = 360 / allSecondsInDay;
    const float fullCycle = 60f;

	void Start () {
		
	}
	
	void Update () {
        actualRotate = degreesPerSecond * allSecondsInDay / (minutesPerCycle * 60);
        this.transform.Rotate(new Vector3(actualRotate, 0, 0) * Time.deltaTime);

        timeDay += Time.deltaTime / minutesPerCycle;
        if (timeDay >= fullCycle) timeDay = 0;

        if (timeDay > fullCycle / 2 && timeDay < fullCycle / 2 + 10) {
            if (sunLight.intensity > minIntensity)
                sunLight.intensity -= speedIntensity * Time.deltaTime;

            if (RenderSettings.ambientIntensity > minAmbient)
                RenderSettings.ambientIntensity -= speedIntensity * Time.deltaTime;

            RenderSettings.skybox = skyboxNight;
            DynamicGI.UpdateEnvironment();
        }

        else
        if (timeDay > fullCycle - 5 || timeDay < 10) {
            if (sunLight.intensity < maxIntensity)
                sunLight.intensity += speedIntensity * Time.deltaTime;

            if (RenderSettings.ambientIntensity < maxAmbient)
                RenderSettings.ambientIntensity += speedIntensity * Time.deltaTime;

            RenderSettings.skybox = skyboxDay;
            DynamicGI.UpdateEnvironment();
        }

        Debug.Log($"{fullCycle / 2 + 10}");
	}


    private void OnGUI() {
        System.TimeSpan timeSpan = System.TimeSpan.FromHours(timeDay / fullCycle * 24);

        GUI.Label(new Rect(20, 0, 300, 20), $"Czas: {timeSpan.Hours + 6}:{timeSpan.Minutes}");
        GUI.Label(new Rect(20, 20, 300, 20), $"Intensywnosc: {RenderSettings.ambientIntensity}");
    }
}
