using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour {
    public GameMgr.GunType gunType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Parcel parcel = other.GetComponent<Parcel>();
        if(parcel != null)
        {
            GetItem();
        }
    }

    public void GetItem()
    {
        GameMgr.Instance.GetItem(this.gunType);
        GameObject.DestroyObject(this.gameObject);
    }
}
