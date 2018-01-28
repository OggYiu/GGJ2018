using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    public enum GunType
    {
        HAND_GUN,
        MACHINE_GUN,
        SHORT_GUN,
        ROCKET_LAUNCHER,
    }

    public bool showGameStart = false;
    public string nextLevel;
    public GunType initGunType;
    public Gun[] guns;
    public bool isGameStarted = false;
    public bool isGameEnded = false;
    public SpriteRenderer fadeInOutSpirteRenderer;
    public AudioSource audioChangeGun;
    private StageUI stageUI;
    private GameUIMgr gameUIMgr;

    private Gun myGun;
    private Parcel parcel;

    protected GameMgr()
    {
    }

    public void FadeIn()
    {
        this.fadeInOutSpirteRenderer.gameObject.SetActive(true);
        this.fadeInOutSpirteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("from", this.fadeInOutSpirteRenderer.color);
        tweenParams.Add("to", new Color(1.0f, 1.0f, 1.0f, 0f));
        tweenParams.Add("time", 3.0);
        tweenParams.Add("onupdate", "OnColorUpdated");
        tweenParams.Add("oncomplete", "OnFadeInEnded");

        iTween.ValueTo(this.gameObject, tweenParams);
    }

    private void OnFadeInEnded()
    {
        //this.fadeInOutSpirteRenderer.gameObject.SetActive(false);
    }

    private void OnFadeOutEnded()
    {
        SceneManager.LoadScene(this.nextLevel);
    }

    private void OnColorUpdated(Color color)
    {
        this.fadeInOutSpirteRenderer.color = color;
    }

    public void FadeOut()
    {
        this.fadeInOutSpirteRenderer.gameObject.SetActive(true);
        this.fadeInOutSpirteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("from", this.fadeInOutSpirteRenderer.color);
        tweenParams.Add("to", new Color(1.0f, 1.0f, 1.0f, 1.0f));
        tweenParams.Add("time", 3.0);
        tweenParams.Add("onupdate", "OnColorUpdated");
        tweenParams.Add("oncomplete", "OnFadeOutEnded");

        iTween.ValueTo(this.gameObject, tweenParams);
    }

    // Use this for initialization
    void Start()
    {
        this.gameUIMgr = FindObjectOfType<GameUIMgr>();
        this.stageUI = FindObjectOfType<StageUI>();

        this.FadeIn();

        this.parcel = FindObjectOfType<Parcel>();

        if (this.showGameStart)
        {
            Rigidbody body = this.parcel.GetComponent<Rigidbody>();
            body.isKinematic = true;
            body.useGravity = false;
            this.stageUI.ShowStageBegin();
        }
        else
        {
            OnLevelStarted();
        }

        foreach (Gun gun in guns)
        {
            gun.gameObject.SetActive(false);
        }

        ChangeWeapon(initGunType);
    }

    // Update is called once per frame
    void Update()
    {

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

        audioChangeGun.Play();
    }

    public void OnLevelStarted()
    {
        isGameStarted = true;

        Rigidbody body = this.parcel.GetComponent<Rigidbody>();
        body.isKinematic = false;
        body.useGravity = true;
    }

    public void OnLevelEnded()
    {
        Rigidbody body = this.parcel.GetComponent<Rigidbody>();
        body.isKinematic = true;
        body.useGravity = false;

        isGameEnded = true;

        FadeOut();
    }

    public void OnGotHit(GameUIMgr.GotHitType type)
    {
        this.gameUIMgr.ShowGotHit(type);
    }

    public void OnGotScore(GameUIMgr.GotScoreType type, GameObject target)
    {
        this.gameUIMgr.ShowGotScore(type, target);
    }

    public void GetItem(GunType gunType)
    {
        ChangeWeapon(gunType);
    }
}
