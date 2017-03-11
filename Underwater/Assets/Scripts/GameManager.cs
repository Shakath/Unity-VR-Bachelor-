using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Transform terrainPrefab;
	private Transform terrainObject;
	// Use this for initialization
	void Start () {
		terrainObject = (Transform)Instantiate (terrainPrefab, terrainPrefab.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
