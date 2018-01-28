using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour {
    public GameMgr.GunType gunType;
    public GameMgr gameMgr;

	// Use this for initialization
	void Start () {
        this.gameMgr = FindObjectOfType<GameMgr>();

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
        this.gameMgr.GetItem(this.gunType);
        GameObject.DestroyObject(this.gameObject);
    }
}
