using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMoving : MonoBehaviour {

	public bool Flip = false;
	public float Speed = 10f;

	private Transform Bird;
	private bool StartFly = false;

	// Use this for initialization
	void Start () {
		Bird = this.gameObject.transform;

		if (Flip) {
			Speed *= -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (StartFly) {
			Bird.localPosition = new Vector3 (Bird.localPosition.x + (Speed * Time.deltaTime), Bird.localPosition.y, Bird.localPosition.z);
		}

		if (Bird.localPosition.x < -30 || Bird.localPosition.x > 30) {
			DestroyObject(Bird);
			StartFly = false;
		}
	}

	private void OnTriggerEnter(Collider other) {
		StartFly = true;
	}
}
