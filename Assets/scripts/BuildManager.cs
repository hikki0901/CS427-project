﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public GameObject[] tower;
	public GameObject[] selectionTower;
	public float[] initialTowerValue;
	public float[] initialTowerScore;

	private int towerToBuildIndex;
	private GameObject towerToBuild;
	private GameObject selectionTowerToBuild;
	private GameObject selectionTowerToBuildInstance;
	private SoulsCounter soulsCounter;

	public GameObject GetSelectionTowerToBuild()
    {
		return selectionTowerToBuild;
	}

	public void SetSelectionTowerToBuild (GameObject selecTower)
    {
		selectionTowerToBuild = selecTower;
	}

	public void DestroySelectionTowerToBuildInstance()
    {
		Destroy(selectionTowerToBuildInstance);
	}

	public void SetSelectionTowerToBuildInstance(GameObject selectionT)
    {
		selectionTowerToBuildInstance = selectionT;
	}

	public GameObject GetTowerToBuild()
    {
		return towerToBuild;
	}
		
	public int GetTowerToBuildIndex()
    {
		return towerToBuildIndex;
	}

	public void SetTowerToBuild (GameObject tower)
    {
		towerToBuild = tower;
	}

	public void SetTowerToBuildIndex (int index)
    {
		towerToBuildIndex = index;
	}

	private void Awake()
    {
		towerToBuildIndex = 0;
		towerToBuild = null;
		soulsCounter = gameObject.GetComponent<SoulsCounter> ();
	}

	private void Start()
    {
		soulsCounter.SetInitialTowersValues (initialTowerValue);
	}
}	