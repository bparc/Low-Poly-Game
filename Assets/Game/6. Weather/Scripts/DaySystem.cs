using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystem : MonoBehaviour {
    [Header("Objects")]
    public Material skyboxDay;
    public Material skyboxNight;
    public Light sunLight;
    public ParticleSystem stars;

    [Header("Velocity")]
    public float minutesPerCycle = 1f;
    public float speedIntensity = 0.2f;

    [Header("Min-Max Settings")]
    public float minIntensity = 0f;
    public float maxIntensity = 1f;

    public float minAmbient = 0f;
    public float maxAmbient = 1f;


    private float actualRotate, timeDay = 0f;
    private float mixSkyboxes = 0;

    const float allSecondsInDay = (60 * 60 * 24);
    const float degreesPerSecond = 360 / allSecondsInDay;
    const float fullCycle = 60f;

	void Start () {
		this.transform.eulerAngles.Set(0, 0, 0);
        this.transform.localRotation.eulerAngles.Set(0, 0, 0);
	}
	
	void Update () {
        actualRotate = degreesPerSecond * allSecondsInDay / (minutesPerCycle * 60);
        this.transform.Rotate(new Vector3(actualRotate, 0, 0) * Time.deltaTime);

        timeDay += Time.deltaTime / minutesPerCycle;
        if (timeDay >= fullCycle) timeDay = 0;

        if (timeDay > fullCycle / 2 && timeDay < fullCycle / 2 + 15) {
            if (sunLight.intensity > minIntensity)
                sunLight.intensity -= speedIntensity * Time.deltaTime / minutesPerCycle;

            if (RenderSettings.ambientIntensity > minAmbient)
                RenderSettings.ambientIntensity -= speedIntensity * Time.deltaTime / minutesPerCycle;

            mixSkyboxes += speedIntensity * Time.deltaTime / minutesPerCycle;
            RenderSettings.skybox.Lerp(RenderSettings.skybox, skyboxNight, mixSkyboxes); 

            DynamicGI.UpdateEnvironment();
        }

        else
        if (timeDay > fullCycle - 5 || timeDay < 15) {
            if (sunLight.intensity < maxIntensity)
                sunLight.intensity += speedIntensity * Time.deltaTime / minutesPerCycle;

            if (RenderSettings.ambientIntensity < maxAmbient)
                RenderSettings.ambientIntensity += speedIntensity * Time.deltaTime / minutesPerCycle;

            //stars.addAlpha() //TODO

            mixSkyboxes -= speedIntensity * Time.deltaTime / minutesPerCycle;
            RenderSettings.skybox.Lerp(RenderSettings.skybox, skyboxDay, Mathf.Abs(mixSkyboxes - 1));

            DynamicGI.UpdateEnvironment();
        }

        if (mixSkyboxes > 1f) mixSkyboxes = 1f;
        if (mixSkyboxes < 0f) mixSkyboxes = 0f;
	}


    private void OnGUI() {
        System.TimeSpan timeSpan = System.TimeSpan.FromHours(timeDay / fullCycle * 24 + 6);

        GUI.Label(new Rect(20, 0, 300, 20), $"Time: {timeSpan.Hours}:{timeSpan.Minutes}");
    }
}
