using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 camPos = Camera.main.transform.position;
        this.transform.position = new Vector3(camPos.x, camPos.y, 0);

    }
}
