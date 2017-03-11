using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyTerrain : MonoBehaviour {
	private Terrain terrain;
	public GameObject Terrain;
	public float strength = 0.01f;
	public float modifyRange = 2f;
	Vector3 terrainPos;

    public GameObject particle;
	public int particleSpawnInterval;
	private int particleSpawnTimer = 3;
	private int particleCount = 0;




	public Controller controllerLeft;


	private int heightmapWidth;
	private int heightmapHeight;
	private float[,] heights;
	private float[,] defaultMap;
	private TerrainData terrainData;


	void Start () {

		terrain = GameObject.FindGameObjectWithTag ("Terrain").GetComponent<Terrain>();
		terrainPos = GameObject.FindGameObjectWithTag ("Terrain").transform.position;
		particleSpawnTimer = 0;

		terrainData = terrain.terrainData;
		heightmapWidth = terrainData.heightmapWidth;
		heightmapHeight = terrainData.heightmapHeight;
		heights = terrainData.GetHeights (0, 0, heightmapWidth, heightmapHeight);
		defaultMap = terrainData.GetHeights (0, 0, heightmapWidth, heightmapHeight);
	}
	
	// Update is called once per frame
	void Update () {

		/*
		RaycastHit hit;

		Ray ray = new Ray (Vector3.zero, Vector3.forward);
		Debug.DrawRay (ray.origin,ray.direction , Color.red);
		if (Input.GetMouseButton (0)) {
			if (Physics.Raycast (ray, out hit)) {
				RaiseTerrain (hit.point);

			}
		}

		if (Input.GetMouseButton (1)) {
			if (Physics.Raycast (ray, out hit, 4f)) {
				LowerTerrain (hit.point);
			}
		}
		*/
	}

	public void resetTerrain(){
		Debug.Log ("RESET");
		terrainData.SetHeights (0, 0, defaultMap);
	}

	public void RaiseTerrain(Vector3 point, int diameter){
		AlterTerrain (point, diameter, strength);
	}

	public void LowerTerrain(Vector3 point, int diameter){
		AlterTerrain (point, diameter, -strength);
	}

	public void AlterTerrain(Vector3 point, int diameter, float amount){
		int radius = diameter / 2;
		int ranrad = (int)(radius / 1.5f);
		int mouseX = (int)((point.x / terrainData.size.x) * heightmapWidth) + Random.Range(-ranrad, ranrad);
		int mouseZ = (int)((point.z / terrainData.size.z) * heightmapHeight) + Random.Range(-ranrad, ranrad);

		float[,] modifiedHeights = terrainData.GetHeights (mouseX-radius, mouseZ-radius, diameter, diameter);

		float modAmount = Time.deltaTime * amount;

		for (int x = -radius; x < radius; x++) {
			for (int z = -radius; z < radius; z++) {
				float d2 = (x * x + z * z)/(radius*radius);
				if (d2 > 1)
					continue;
				modifiedHeights [x + radius, z + radius] += modAmount * (1-d2);
			}
		}

		terrainData.SetHeights (mouseX-radius, mouseZ-radius, modifiedHeights);


		particleSpawnTimer++;
		if(particleSpawnTimer >= particleSpawnInterval){
            Instantiate(particle, point, Quaternion.Euler(-90, 0, 0));

            particleSpawnTimer = 0;
		}

	}
}
