using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
	public float destroyTime = 5f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
	}
}
