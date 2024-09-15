using System;
using System.Collections;
using UnityEngine;

public class WeatherScript : MonoBehaviour {
    public float weatherChangeInterval;
    public float rainDuration;
    public AudioClip rainSound;
    public AudioClip lightningSound;
    private ParticleSystem rain;
    private Light lightning;
    private Light sun;
    private AudioSource[] audioSource;

    void Start() {
        if (rainDuration > weatherChangeInterval) {
            throw new Exception("Rain duration must be less than weather change interval");
        }
        rain = GameObject.Find("Rain").GetComponent<ParticleSystem>();
		lightning = GameObject.Find("Lightning").GetComponent<Light>();
        sun = GameObject.Find("Sun").GetComponent<Light>();
        audioSource = GetComponents<AudioSource>();
        StartCoroutine(ChangeWeather());
    }

    IEnumerator ChangeWeather() {
        while (true) {
            // StartCoroutine(Rain()); // DEBUG
            // Weather always starts with a clear sky
            yield return new WaitForSeconds(weatherChangeInterval);
            int dice = UnityEngine.Random.Range(1, 100);
            // 35% chance of rain
            if (dice > 65) {
                StartCoroutine(Rain());
            } 
        }
    }

    IEnumerator Rain() {
        float originalIntensity = sun.intensity;
        rain.Play();
        audioSource[0].loop = true;
        audioSource[0].clip = rainSound;
        audioSource[0].Play();
        sun.intensity = 0.5f;
        int dice = UnityEngine.Random.Range(1, 3);
        // 33% chance of lightning
        // dice = 3; // DEBUG
        if (dice == 3) {
            StartCoroutine(Lightning());
        }
        yield return new WaitForSeconds(rainDuration);
        float volume = audioSource[0].volume;
        while (audioSource[0].volume > 0 && sun.intensity < originalIntensity) {
            if (sun.intensity < originalIntensity) {
                sun.intensity += 0.1f;
            }
            if (audioSource[0].volume > 0) {
                audioSource[0].volume -= 0.1f;
            }
            yield return new WaitForSeconds(0.1f);
        }
        audioSource[0].Stop();
        audioSource[0].volume = volume;
        rain.Stop();
    }

    IEnumerator Lightning() {
        while (true) {
            // Look at some random point below the current position
            lightning.transform.eulerAngles = new Vector3(
                UnityEngine.Random.Range(30, 150), 
                UnityEngine.Random.Range(0, 360),
                UnityEngine.Random.Range(0, 360)
            );
            lightning.enabled = true;
            audioSource[1].PlayOneShot(lightningSound);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1.0f));
            lightning.enabled = false;
            yield return new WaitForSeconds(UnityEngine.Random.Range(10, 30));
        }
    }
}