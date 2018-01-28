using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesusTrigger : MonoBehaviour {
    public GameObject prefabSpineAnimation;
    private bool showed = false;
    private Parcel parcel;
    private GameMgr gameMgr;

	// Use this for initialization
	void Start ()
    {
        this.parcel = FindObjectOfType<Parcel>();
        this.gameMgr = FindObjectOfType<GameMgr>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Parcel parcel = other.GetComponent<Parcel>();
        if(parcel != null && !showed)
        {
            showed = true;
            GameObject spineAnim = GameObject.Instantiate(prefabSpineAnimation);
            Camera camera = Camera.main;
            spineAnim.transform.localPosition = new Vector3(0, 1f, 1);
            spineAnim.transform.parent = camera.transform;
            spineAnim.transform.localPosition = new Vector3(0, 1f, 1);

            this.parcel.enabled = false;
            this.gameMgr.isGameEnded = true;
        }
    }
}
