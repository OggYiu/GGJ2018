using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCamera : MonoBehaviour {
	bool isDownPressed = false;
	bool isUpPressed = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp (KeyCode.W)) {
			isUpPressed = true;
			isDownPressed = false;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			isDownPressed = true;
			isUpPressed = false;
		}

		if(isDownPressed) {
			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y - 0.2f, Camera.main.transform.position.z);
		}

		if(isUpPressed) {
			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x, Camera.main.transform.position.y + 0.2f, Camera.main.transform.position.z);
		}
		
	}
}
