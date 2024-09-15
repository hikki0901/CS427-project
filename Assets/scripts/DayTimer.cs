using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimer : MonoBehaviour {
	public float speedFactor;
	private Light sun;
	private Light moon;
	private ParticleSystem lightning;
	private Color originalMoonColor;
	private float originalMoonIntensity;
	private int isBloodMoon; // 0 = neutral, 10 = blood moon, 1-9 = normal moon
	private WaveSpawner waveSpawner;


	void Start () {
		sun = GameObject.Find("Sun").GetComponent<Light>();
		moon = GameObject.Find("Moon").GetComponent<Light>();
        waveSpawner = GameObject.Find("GameMaster").GetComponent<WaveSpawner>();
		isBloodMoon = 0;
	}

	void FixedUpdate () {
		if (sun.transform.position.y >= 0) {
			sun.enabled = true;
			moon.enabled = false;
			if (isBloodMoon == 10) {
				// Reset moon to normal
				moon.color = originalMoonColor;
				moon.intensity = originalMoonIntensity;
				// Reset enemy stats
				waveSpawner.eventMultiplier /= 1.5f;
			}
			isBloodMoon = 0;
		}
		else {
			moon.enabled = true;
			sun.enabled = false;
			if (isBloodMoon == 0) {
				isBloodMoon = UnityEngine.Random.Range(1, 10);
				if (isBloodMoon == 10) {
					// Set moon to blood moon
					originalMoonColor = moon.color;
					originalMoonIntensity = moon.intensity;
					moon.color = Color.red;
					moon.intensity = 1.0f;
					// Adjust enemy stats
					waveSpawner.eventMultiplier *= 1.5f;
				}
			}
		}
		sun.transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * 0.5f * speedFactor);
		sun.transform.LookAt(Vector3.zero);
		moon.transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * 0.5f * speedFactor);
		moon.transform.LookAt(Vector3.zero);
	}
}
