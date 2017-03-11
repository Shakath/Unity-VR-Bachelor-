using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawning : MonoBehaviour {

	public GameObject fishPrefab;

	public int numFish = 5;
	public int spawnRange = 10;
	public GameObject[] arrFish;
	public static Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
		arrFish = new GameObject[numFish];
		for (int i = 0; i < numFish; i++) {
			Vector3 euler = transform.eulerAngles;
			euler.z = Random.Range(0f, 360f);

			Vector3 pos = new Vector3 (this.transform.position.x + Random.Range (-spawnRange, spawnRange),this.transform.position.y + 
				3, this.transform.position.z +
				Random.Range (-spawnRange, spawnRange));
			arrFish [i] = (GameObject)Instantiate (fishPrefab, pos, Quaternion.Euler (0, 0, 0));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
