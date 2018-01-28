using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChansHand : MonoBehaviour {
    private StageUI stageUI;
	// Use this for initialization
	void Start () {
        this.stageUI = FindObjectOfType<StageUI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        Parcel parcel = other.gameObject.GetComponent<Parcel>();
        if(parcel != null)
        {
            Rigidbody body = parcel.GetComponent<Rigidbody>();
            body.useGravity = false;
            body.isKinematic = true;

            this.stageUI.ShowStageClear();
        }
    }
}
