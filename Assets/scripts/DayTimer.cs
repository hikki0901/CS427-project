using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimer : MonoBehaviour {
	private Light sun;

	void Start () {
		sun = GetComponent<Light>();
	}

	void Update () {
		sun.transform.RotateAround(Vector3.zero, Vector3.right, Time.deltaTime * 0.5f);
	}
}
