using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public Transform Background1;
	public Transform cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Background1.localPosition = new Vector3 (Background1.localPosition.x, cam.position.y, Background1.localPosition.z);
	}
}
