using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelCamera : MonoBehaviour {
    private Parcel parcel;
    public float offsetY = 0;

	// Use this for initialization
	void Start () {
        parcel = FindObjectOfType<Parcel>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 parcelPos = parcel.transform.position;
        Vector3 camPos = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(camPos.x, parcelPos.y - this.offsetY, camPos.z);

    }
}
