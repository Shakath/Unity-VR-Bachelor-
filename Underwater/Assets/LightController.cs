using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    public GameObject flashLight;
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;
    bool lighting = false;

    // Use this for initialization
    void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            lighting = !lighting;
        }
        if(lighting == true)
        {
            flashLight.SetActive(true);
        }else
        {
            flashLight.SetActive(false);
        }
            
    }
}
