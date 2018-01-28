using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		iTween.MoveBy(gameObject, iTween.Hash("y", 0.5, "easeType", "easeInOutExpo", "loopType", "pingPong"));

	}
}
