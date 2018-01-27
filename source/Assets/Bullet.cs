using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 fromPosition;
    public Vector3 targetPosition;
    public Gun gun;
    public GameObject prefabGunFire;
    public float speed = 20f;
    private float lifeCountDown = 0;
    private bool bulletHoleCreated = false;
    private float life = 0;

    // Use this for initialization
    void Start () {
        this.transform.position = fromPosition;
        Vector3 diffPosition = (targetPosition - fromPosition);
        float distance = diffPosition.magnitude;
        this.life = distance / this.speed;
        Rigidbody2D body = this.gameObject.GetComponent<Rigidbody2D>();
        diffPosition.Normalize();
        body.velocity = diffPosition * speed;
        //Debug.Log("start!");
        this.lifeCountDown = this.life;
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.lifeCountDown -= Time.deltaTime;
        if(!bulletHoleCreated)
        {
            if (this.lifeCountDown <= 0)
            {
                // create gunFire
                GameObject gunFire = GameObject.Instantiate(prefabGunFire);
                gunFire.transform.position = new Vector3(targetPosition.x, targetPosition.y, -1);
                GameObject.DestroyObject(gunFire, 1.0f);
                bulletHoleCreated = true;

                this.gun.OnBulletHitPosition(this.targetPosition);
                GameObject.DestroyObject(this.gameObject);
            }
        }

    }
}
