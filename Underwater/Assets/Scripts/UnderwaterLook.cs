using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterLook : MonoBehaviour {
	private Camera main;
	private Color underwaterColor;
	public float fogDensity = 0.2f;
	// Use this for initialization
	void Start () {
		main = GetComponent<Camera> ();
		underwaterColor = main.backgroundColor;
		RenderSettings.fogColor = underwaterColor;
		RenderSettings.fogDensity = fogDensity;
		RenderSettings.fog = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
