using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChansHand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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

            StageUI.Instance.ShowStageClear();
        }
    }
}
