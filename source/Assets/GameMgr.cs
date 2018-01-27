using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : Singleton<GameMgr> {
    public enum GunType {
        HAND_GUN,
        MACHINE_GUN,
    }

    public GunType initGunType;
    public Gun[] guns;
    private Gun myGun;

    protected GameMgr()
    {
    }

    // Use this for initialization
    void Start ()
    {
        foreach (Gun gun in guns)
        {
            gun.gameObject.SetActive(false);
        }

        ChangeWeapon(initGunType);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeWeapon(GunType gunType)
    {
        Gun gun = guns[(int)gunType];

        if (myGun != null)
        {
            myGun.gameObject.SetActive(false);
        }

        myGun = gun;

        if (myGun != null)
        {
            myGun.gameObject.SetActive(true);
        }
    }
}
