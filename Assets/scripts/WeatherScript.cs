using System;
using System.Collections;
using UnityEngine;

public class WeatherScript : MonoBehaviour {
    public float weatherChangeInterval;
    public float rainDuration;
    public float bloodMoonDuration;
    public AudioClip rainSound;
    private GameObject rain;
    private GameObject sun;
    //private AudioSource audioSource;

    public enum Weather {
        Sunny,
        Rainy,
        BloodMoon,
    }

    void Start() {
        if (bloodMoonDuration > weatherChangeInterval) {
            throw new Exception("Blood moon duration must be less than weather change interval");
        }
        else if (rainDuration > weatherChangeInterval) {
            throw new Exception("Rain duration must be less than weather change interval");
        }
        rain = GameObject.Find("Rain");
        sun = GameObject.Find("Sun");
        //audioSource = GetComponent<AudioSource>();
        StartCoroutine(ChangeWeather());
    }

    IEnumerator ChangeWeather() {
        while (true) {
            yield return new WaitForSeconds(weatherChangeInterval);
            int dice = UnityEngine.Random.Range(1, 10);
            if (dice == 10) {
                StartCoroutine(BloodMoon());
            }
            else if (dice >= 7) {
                StartCoroutine(Rain());
            }
        }
    }

    IEnumerator Rain() {
        ParticleSystem particleSystem = rain.GetComponent<ParticleSystem>();
        particleSystem.Play();
        //audioSource.PlayOneShot(rainSound);
        yield return new WaitForSeconds(rainDuration);
        particleSystem.Stop();
        //audioSource.Stop();
    }

    IEnumerator BloodMoon() {
        Light light = sun.GetComponent<Light>();
        Color originalSunColor = light.color;
        light.color = Color.red;
        yield return new WaitForSeconds(bloodMoonDuration);
        light.color = originalSunColor;
    }
}