using System;
using System.Collections;
using UnityEngine;

public class WeatherScript : MonoBehaviour {
    public float weatherChangeInterval;
    public float rainDuration;
    public AudioClip rainSound;
    private GameObject rain;
    public GameObject sun;

    private AudioSource[] audioSource;
    
    void Start() {
        if (rainDuration > weatherChangeInterval) {
            throw new Exception("Rain duration must be less than weather change interval");
        }
        rain = GameObject.Find("Rain");
        sun = GameObject.Find("Sun");
        audioSource = GetComponents<AudioSource>();
        StartCoroutine(ChangeWeather());
    }

    IEnumerator ChangeWeather() {
        while (true) {
            // StartCoroutine(Rain());
            yield return new WaitForSeconds(weatherChangeInterval);
            int dice = UnityEngine.Random.Range(1, 10);
            // 30% chance of rain
            if (dice > 7) {
                StartCoroutine(Rain());
            } 
        }
    }

    IEnumerator Rain() {
        ParticleSystem particleSystem = rain.GetComponent<ParticleSystem>();
        Light light = sun.GetComponent<Light>();
        float originalIntensity = light.intensity;
        particleSystem.Play();
        audioSource[0].clip = rainSound;
        audioSource[0].Play();
        light.intensity = 0.5f;
        int dice = UnityEngine.Random.Range(0, 1);
        yield return new WaitForSeconds(rainDuration);
        particleSystem.Stop();
        audioSource[0].Stop();
        light.intensity = originalIntensity;
    }
}