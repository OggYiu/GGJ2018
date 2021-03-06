﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScroll : MonoBehaviour {

	public Transform Background1;
	public Transform Background2;
	public Transform Background3;
	public int MaxFloor;

	private int CurrentBackground = 1;
	public Transform cam;

	private const float Height = 11.8f;
	private float CurrentHeight = Height*2;
	private float BackgroundHeight = Height;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (cam.position.y >= CurrentHeight + 5) {

			//Debug.Log ("Height " + CurrentHeight);
			if (CurrentHeight / Height <= MaxFloor + 0.01) {
				if (CurrentBackground == 1) {
					Background1.localPosition = new Vector3 (0, Background1.localPosition.y + BackgroundHeight * 3, 0);
				} else if (CurrentBackground == 2) {
					Background2.localPosition = new Vector3 (0, Background2.localPosition.y + BackgroundHeight * 3, 0);
				} else if (CurrentBackground == 3) {
					Background3.localPosition = new Vector3 (0, Background3.localPosition.y + BackgroundHeight * 3, 0);
				}

				CurrentHeight += Height;
				CurrentBackground += 1;
				if (CurrentBackground == 4) {
					CurrentBackground = 1;
				}
			}
		} else if (cam.position.y + Height < CurrentHeight && cam.position.y > Height) {
			CurrentHeight -= Height;
			CurrentBackground -= 1;
			if (CurrentBackground == 0) {
				CurrentBackground = 3;
			}

			if (CurrentBackground == 1) {
				Background1.localPosition = new Vector3 (0, Background1.localPosition.y - BackgroundHeight * 3, 0);
			} else if (CurrentBackground == 2) {
				Background2.localPosition = new Vector3 (0, Background2.localPosition.y - BackgroundHeight * 3, 0);
			} else if (CurrentBackground == 3) {
				Background3.localPosition = new Vector3 (0, Background3.localPosition.y - BackgroundHeight * 3, 0);
			}

		}

	}
}
