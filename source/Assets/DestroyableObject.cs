using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour {
    public AudioSource destroySound;
    private Rigidbody body;
    private BoxCollider boxCollider;
    private Vector3 backupPos;
    private bool isSelfDestroyStarted = false;
    const float SELF_DESTROY_TIME = 4.0f;
    private float lifeTimeAfterSelfDestroyStarted = SELF_DESTROY_TIME;
    private bool isDead = false;
    private SpriteRenderer spriteRenderer;
    private GameMgr gameMgr;
    private CameraShake cameraShake;

    //private Vector3 backupPos;

    // Use this for initialization
    void Start () {
        this.body = this.gameObject.GetComponent<Rigidbody>();
        this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        this.boxCollider = this.gameObject.GetComponent<BoxCollider>();
        this.backupPos = this.transform.position;
        this.gameMgr = FindObjectOfType<GameMgr>();
        this.cameraShake = FindObjectOfType<CameraShake>();
    }
	
	// Update is called once per frame
	void Update () {
        if(this.isDead)
        {
            return;
        }

		if(isSelfDestroyStarted)
        {
            this.lifeTimeAfterSelfDestroyStarted -= Time.deltaTime;
            this.spriteRenderer.color = new Color(this.spriteRenderer.color.r, this.spriteRenderer.color.g, this.spriteRenderer.color.b, this.lifeTimeAfterSelfDestroyStarted / SELF_DESTROY_TIME);
            if (this.lifeTimeAfterSelfDestroyStarted <= 0)
            {
                DestroyObject(this.gameObject);
                this.isDead = true;
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        Parcel parcel = collision.gameObject.GetComponent<Parcel>();
        if (parcel != null)
        {
            this.body.useGravity = true;
            this.gameMgr.OnGotHit(GameUIMgr.GotHitType.MINUS_10);
            this.cameraShake.ShakeCamera(0.2f, 0.1f);
            StartSelfDestroy();
        }
    }

    public void StartSelfDestroy()
    {
        isSelfDestroyStarted = true;
        this.boxCollider.enabled = false;
        destroySound.Play();
    }
}
