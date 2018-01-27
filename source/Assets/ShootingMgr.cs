using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMgr : MonoBehaviour {
    public Gun myGun;
    public Gun[] guns;
    public GameObject box;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 boxPosition = box.transform.position;
        Vector3 cameraPosition = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(cameraPosition.x, boxPosition.y, cameraPosition.z);
    }
}
