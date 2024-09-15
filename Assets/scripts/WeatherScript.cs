using System;
using System.Collections;
using UnityEngine;

public class WeatherScript : MonoBehaviour {
    public float weatherChangeInterval;
    public float rainDuration;
    public AudioClip rainSound;
    private ParticleSystem rain;
    private ParticleSystem lightning;
    private Vector3 lightningPosition;
    public Light sun;

    private AudioSource[] audioSource;

    void Start() {
        if (rainDuration > weatherChangeInterval) {
            throw new Exception("Rain duration must be less than weather change interval");
        }
        rain = GameObject.Find("Rain").GetComponent<ParticleSystem>();
		lightning = GameObject.Find("Lightning").GetComponent<ParticleSystem>();
        lightningPosition = new Vector3(lightning.transform.position.x, lightning.transform.position.y, lightning.transform.position.z);
        sun = GameObject.Find("Sun").GetComponent<Light>();
        audioSource = GetComponents<AudioSource>();
        StartCoroutine(ChangeWeather());
    }

    IEnumerator ChangeWeather() {
        while (true) {
            StartCoroutine(Rain());
            yield return new WaitForSeconds(weatherChangeInterval);
            int dice = UnityEngine.Random.Range(1, 10);
            // 30% chance of rain
            if (dice > 7) {
                StartCoroutine(Rain());
            } 
        }
    }

    IEnumerator Rain() {
        float originalIntensity = sun.intensity;
        rain.Play();
        audioSource[0].clip = rainSound;
        audioSource[0].Play();
        sun.intensity = 0.5f;
        StartCoroutine(Lightning());
        yield return new WaitForSeconds(rainDuration);
        rain.Stop();
        audioSource[0].Stop();
        sun.intensity = originalIntensity;
    }

    IEnumerator Lightning() {
        while (true) {
            lightning.transform.position = new Vector3(lightningPosition.x + UnityEngine.Random.Range(-10, 10), lightningPosition.y, lightningPosition.z + UnityEngine.Random.Range(-10, 10));
            lightning.Play();
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 5));
        }
    }
}