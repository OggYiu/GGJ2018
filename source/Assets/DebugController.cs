using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour {

    public float speed = 20f;
    private Parcel parcel;
    Dictionary<KeyCode, bool> keyDownChecker = new Dictionary<KeyCode, bool>();

    // Use this for initialization
    void Start()
    {
        parcel = FindObjectOfType<Parcel>();
        parcel.GetComponent<Rigidbody>().isKinematic = true;

        KeyCode targetKeyCode;
        targetKeyCode = KeyCode.W;
        keyDownChecker[targetKeyCode] = false;
        targetKeyCode = KeyCode.S;
        keyDownChecker[targetKeyCode] = false;
        targetKeyCode = KeyCode.A;
        keyDownChecker[targetKeyCode] = false;
        targetKeyCode = KeyCode.D;
        keyDownChecker[targetKeyCode] = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        KeyCode targetKeyCode;

        // Keycode W
        {
            targetKeyCode = KeyCode.W;
            if (Input.GetKeyUp(targetKeyCode))
            {
                keyDownChecker[targetKeyCode] = false;
            }

            if (Input.GetKeyDown(targetKeyCode))
            {
                keyDownChecker[targetKeyCode] = true;
            }

            if (keyDownChecker[targetKeyCode]) {
                Vector3 parcelPos = parcel.transform.position;
                parcel.transform.position = new Vector3(parcelPos.x, parcelPos.y + speed * Time.deltaTime, parcelPos.z);
            }
        }

        // Keycode S
        {
            targetKeyCode = KeyCode.S;
            if (Input.GetKeyUp(targetKeyCode))
            {
                keyDownChecker[targetKeyCode] = false;
            }

            if (Input.GetKeyDown(targetKeyCode))
            {
                keyDownChecker[targetKeyCode] = true;
            }

            if (keyDownChecker[targetKeyCode])
            {
                Vector3 parcelPos = parcel.transform.position;
                parcel.transform.position = new Vector3(parcelPos.x, parcelPos.y - speed * Time.deltaTime, parcelPos.z);
            }
        }

        // Keycode A
        {
            targetKeyCode = KeyCode.A;
            if (Input.GetKeyUp(targetKeyCode))
            {
                keyDownChecker[targetKeyCode] = false;
            }

            if (Input.GetKeyDown(targetKeyCode))
            {
                keyDownChecker[targetKeyCode] = true;
            }

            if (keyDownChecker[targetKeyCode])
            {
                Vector3 parcelPos = parcel.transform.position;
                parcel.transform.position = new Vector3(parcelPos.x - speed * Time.deltaTime, parcelPos.y, parcelPos.z);
            }
        }

        // Keycode D
        {
            targetKeyCode = KeyCode.D;
            if (Input.GetKeyUp(targetKeyCode))
            {
                keyDownChecker[targetKeyCode] = false;
            }

            if (Input.GetKeyDown(targetKeyCode))
            {
                keyDownChecker[targetKeyCode] = true;
            }

            if (keyDownChecker[targetKeyCode])
            {
                Vector3 parcelPos = parcel.transform.position;
                parcel.transform.position = new Vector3(parcelPos.x + speed * Time.deltaTime, parcelPos.y, parcelPos.z);
            }
        }
    }
}
