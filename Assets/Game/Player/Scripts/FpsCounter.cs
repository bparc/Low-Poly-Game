using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    public int _UpdatesPerSecond = 60;
    int _fps = 0;
    float _accumulator = 0.0f;

    // Update is called once per frame
    void Update()
    {
        float frequency = 1.0f / (float)_UpdatesPerSecond;

        if (_accumulator >= frequency)
        {
            _fps = (int)(1.0f / Time.deltaTime);
            _accumulator = 0.0f;
        }

        _accumulator += Time.deltaTime;
	}

    void OnGUI()
    {
        GUI.Label(new Rect(5.0f, 5.0f, 100.0f, 25.0f), $"fps:{_fps}");
    }
}
