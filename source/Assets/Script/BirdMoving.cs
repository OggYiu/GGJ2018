using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMoving : MonoBehaviour {

	public bool Flip = false;
	public bool IsUFO = false;
	public float Speed = 10f;

	private Transform Bird;
	private bool StartFly = false;
	private float VerticalSpeed = 5;
	private float IniticalY;
	private float vertical = 0;

	// Use this for initialization
	void Start () {
		Bird = this.gameObject.transform;

		if (IsUFO) {
			IniticalY = Bird.localPosition.y;
			vertical = VerticalSpeed;
		}

		if (Flip) {
			Speed *= -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (IsUFO) {
			if (Bird.localPosition.y > IniticalY + 3 || Bird.localPosition.y < IniticalY - 3) {
				vertical *= -1;
			}
		}

		if (StartFly) {
			Bird.localPosition = new Vector3 (Bird.localPosition.x + (Speed * Time.deltaTime), Bird.localPosition.y + (vertical * Time.deltaTime), Bird.localPosition.z);
		}

		if (Bird.localPosition.x < -30 || Bird.localPosition.x > 30) {
			DestroyObject(this.gameObject);
			StartFly = false;
		}
	}

	private void OnTriggerEnter(Collider other) {
		StartFly = true;
	}
}
