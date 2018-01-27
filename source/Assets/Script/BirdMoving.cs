using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMoving : MonoBehaviour {

	private Transform Bird;
	private bool StartFly = false;

	// Use this for initialization
	void Start () {
		Bird = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (StartFly) {
			Bird.localPosition = new Vector3 (Bird.localPosition.x + 0.1f, Bird.localPosition.y, Bird.localPosition.z);
		}

		Debug.Log ("Start Flying " + Bird.localPosition.x);
		if (Bird.localPosition.x > 30) {
			DestroyObject(Bird);
		}
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log ("Start Flying");
		StartFly = true;
	}
}
