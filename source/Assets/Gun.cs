using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float radius = 0;
    public float power = 0;
    public float coolDown = 0;
    public float upward = 0;
    public bool isAutoWeapon = false;
    public bool isMouseUp = true;
    public GameObject prefabGunFire;
    public float gunFireLife = 0.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonUp(0))
        {
            isMouseUp = true;
        }
        if(Input.GetMouseButtonDown(0))
        {
            isMouseUp = false;

            Vector3 mouseScreenPos = Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            GameObject gunFire = GameObject.Instantiate(prefabGunFire);
            gunFire.transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, -1);
            GameObject.DestroyObject(gunFire, 1.0f);
            
            Vector3 explosionPos = mouseWorldPos;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    rb.AddExplosionForce(power, explosionPos, radius, upward);
                    Debug.Log("hit " + rb.gameObject.name);
                }
            }
        }

		if(coolDown > 0)
        {
            coolDown -= Time.deltaTime;
            if(coolDown <= 0)
            {
                coolDown = 0;
            }
        }
	}

    public bool isReady()
    {
        bool ready1 = coolDown <= 0;
        bool ready2 = true;

        if(!isAutoWeapon)
        {
            ready2 = isMouseUp;
        }
        return ready1 && ready2;
    }
}
