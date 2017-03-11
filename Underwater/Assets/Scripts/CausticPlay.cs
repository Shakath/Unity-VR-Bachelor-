using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausticPlay : MonoBehaviour {
	private Projector projector;
	public MovieTexture movTex;
	// Use this for initialization
	void Start () {
		projector = GetComponent<Projector> ();
		projector.material.SetTexture ("_ShadowTex", movTex);
		movTex.loop = true;
		movTex.Play ();
	}

}
