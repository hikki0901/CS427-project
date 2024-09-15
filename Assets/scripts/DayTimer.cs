using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimer : MonoBehaviour {
	public float speedFactor;
    public float bloodMoonDuration;
	private Light sun;
	private Light moon;
	private Color originalMoonColor;
	private float originalMoonIntensity;
	private int isBloodMoon; // 0 = neutral, 10 = blood moon, 1-9 = normal moon

	void Start () {
		sun = GameObject.Find("Sun").GetComponent<Light>();
		moon = GameObject.Find("Moon").GetComponent<Light>();
		isBloodMoon = 0;
	}

	void Update () {
		if (sun.transform.position.y >= 0) {
			sun.enabled = true;
			moon.enabled = false;
			if (isBloodMoon == 10) {
				moon.color = originalMoonColor;
				moon.intensity = originalMoonIntensity;
			}
			isBloodMoon = 0;
		}
		else {
			moon.enabled = true;
			sun.enabled = false;
			if (isBloodMoon == 0) {
				isBloodMoon = UnityEngine.Random.Range(1, 10);
				if (isBloodMoon == 10) {
					originalMoonColor = moon.color;
					originalMoonIntensity = moon.intensity;
					moon.color = Color.red;
					moon.intensity = 1.0f;
				}
			}
		}
		sun.transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * 0.5f * speedFactor);
		sun.transform.LookAt(Vector3.zero);
		moon.transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * 0.5f * speedFactor);
		moon.transform.LookAt(Vector3.zero);
	}
}
