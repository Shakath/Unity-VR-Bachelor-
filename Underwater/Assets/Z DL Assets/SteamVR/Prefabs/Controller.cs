using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Controller : MonoBehaviour {
	
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;
	public ModifyTerrain modifyTerrain;
	public int toolIndex = 0;
    private VRTK_ControllerEvents grabbing;
    public GameObject particleEffect;


	// Use this for initialization
	void Start () {
        grabbing = GetComponentInChildren<VRTK_ControllerEvents>();
		trackedObject = GetComponent<SteamVR_TrackedObject>();
		modifyTerrain = GameObject.FindGameObjectWithTag ("Terrain").GetComponent<ModifyTerrain> ();
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObject.index);

		Ray ray = new Ray (gameObject.transform.position, gameObject.transform.forward);
		RaycastHit hit;
		Debug.DrawRay (ray.origin,ray.direction , Color.red);

		if (toolIndex == 0) {
            if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
                particleEffect.SetActive(true);
                if (Physics.Raycast(ray, out hit, 4f)) {
                    modifyTerrain.RaiseTerrain(hit.point, 15);
                    
                } 

				Debug.Log ("Trigger pressed");
				device.TriggerHapticPulse (700);
			}
            else
            {
                particleEffect.SetActive(false);
            }
        }
		if (toolIndex == 1) {
			if (device.GetPress (SteamVR_Controller.ButtonMask.Trigger)) {
                particleEffect.SetActive(true);
                if (Physics.Raycast (ray, out hit, 4f)) {
					modifyTerrain.LowerTerrain (hit.point, 15);
                    
                }

				Debug.Log ("Trigger pressed");
				device.TriggerHapticPulse (700);
            }
            else
            {
                particleEffect.SetActive(false);
            }

        }
		if (toolIndex == 2) {
            grabbing.grabToggleButton = VRTK_ControllerEvents.ButtonAlias.Trigger_Press;
        } else {
            grabbing.grabToggleButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
        }

		if (toolIndex == 3) {
			modifyTerrain.resetTerrain ();
			toolIndex = 0;
		}

	}
		
	public void selectTool(int index){
		toolIndex = index;
	}
}