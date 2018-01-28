using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelCamera : MonoBehaviour {
    private Parcel parcel;
    public float offsetY = 0;
    public float targetHeight = 0;
    public GameUIMgr gameUIMgr;

    private float lastUpdatedHeight = 0;
    private bool currentHeightSet = false;

    // Use this for initialization
    void Start () {
        parcel = FindObjectOfType<Parcel>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 parcelPos = parcel.transform.position;
        Vector3 camPos = Camera.main.transform.position;
        float currentHeight = parcelPos.y;

        if (!currentHeightSet)
        {
            lastUpdatedHeight = currentHeight;
            currentHeightSet = true;
        }

        float diffHeight = currentHeight - lastUpdatedHeight;
        Camera.main.transform.position = new Vector3(camPos.x, lastUpdatedHeight - this.offsetY + diffHeight, camPos.z);
        this.gameUIMgr.SetCurrentHeight((int)currentHeight);
        this.gameUIMgr.SetTargetHeight((int)(this.targetHeight - currentHeight));

        lastUpdatedHeight = currentHeight;
    }
}
