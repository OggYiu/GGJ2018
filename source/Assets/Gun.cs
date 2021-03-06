﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float radius = 0;
    public float power = 0;
    public float coolDown = 0;
    public float upward = 0;
    public bool isAutoWeapon = false;
    public Bullet prefabBullet;
    public int numberOfBulletsFire = 1;
    public float gunFireLife = 0.5f;
    public AudioSource fireSound;
    private float shortGunRadius = 1f;

    private float coolDownBK = 0;
    private bool isMouseJustDown = false;
    private bool isMouseUp = true;
    private bool isMouseDown = false;
    private GameMgr gameMgr;

    // Use this for initialization
    void Start() {
        coolDownBK = coolDown;

        this.gameMgr = FindObjectOfType<GameMgr>();
    }

    // Update is called once per frame
    void Update() {
        if (this.gameMgr.isGameEnded || !this.gameMgr.isGameStarted)
        {
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseUp = true;
            isMouseDown = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isMouseJustDown = true;

            isMouseUp = false;
            isMouseDown = true;
        }

        if ((isMouseJustDown || (isAutoWeapon && isMouseDown)) && isCoolDownFinished())
        {
            fireSound.Play();

            Vector3 mouseScreenPos = Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);

            // create bullet
            {
                float screenHeight = Camera.main.orthographicSize * 2.0f;
                Vector3 bulletPos = new Vector3(mouseWorldPos.x, Camera.main.transform.position.y - screenHeight / 2, -1);
                prefabBullet.fromPosition = bulletPos;
                prefabBullet.targetPosition = mouseWorldPos;
                prefabBullet.gun = this;
                Bullet bullet = GameObject.Instantiate(prefabBullet);
            }

            if(this.numberOfBulletsFire > 1)
            {
                for(int i = 0; i < this.numberOfBulletsFire-1; ++i)
                {

                    // create bullet
                    float screenHeight = Camera.main.orthographicSize * 2.0f;
                    Vector3 bulletPos = new Vector3(mouseWorldPos.x, Camera.main.transform.position.y - screenHeight / 2, -1);
                    Vector3 targetPos = mouseWorldPos;
                    targetPos += new Vector3(Random.Range(-this.shortGunRadius, this.shortGunRadius), Random.Range(-this.shortGunRadius, this.shortGunRadius), -1);
                    prefabBullet.fromPosition = bulletPos;
                    prefabBullet.targetPosition = targetPos;
                    prefabBullet.gun = this;
                    Bullet bullet = GameObject.Instantiate(prefabBullet);
                }
            }

            coolDown = coolDownBK;
        }

		if(coolDown > 0)
        {
            coolDown -= Time.deltaTime;
            if(coolDown <= 0)
            {
                coolDown = 0;
            }
        }

        isMouseJustDown = false;

    }

    public bool isCoolDownFinished()
    {
        return coolDown <= 0;
    }

    public void OnBulletHitPosition(Vector3 pos)
    {
        Vector3 explosionPos = pos;
        explosionPos = new Vector3(explosionPos.x, explosionPos.y, -0.001f);
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                //rb.velocity = Vector3.zero;
                //rb.angularVelocity = Vector3.zero;
                rb.AddExplosionForce(power, explosionPos, radius, upward);

                DestroyableObject destroyableObject = rb.GetComponent<DestroyableObject>();
                if(destroyableObject != null)
                {
                    rb.useGravity = true;
                    destroyableObject.StartSelfDestroy();
                    this.gameMgr.OnGotScore(GameUIMgr.GotScoreType.SCORE_10, destroyableObject.gameObject);
                }
                //Debug.Log("hit " + rb.gameObject.name);
            }
        }
    }
}
