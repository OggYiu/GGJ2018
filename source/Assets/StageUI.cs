using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    public Image imageStageBegin;
    public Image imageStageClear;
    const float UI_INIT_POS_X = -350;
    private GameMgr gameMgr;
    // Use this for initialization
    void Start () {
        this.gameMgr = FindObjectOfType<GameMgr>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void ShowStageBegin()
    {
        Vector3 imagePos = imageStageBegin.transform.position;
        imageStageBegin.transform.position = new Vector3(UI_INIT_POS_X, imagePos.y, imagePos.z);
        iTween.MoveTo(imageStageBegin.gameObject, iTween.Hash("x", Screen.width/2, "easeType", "easeInOutExpo", "oncompletetarget", this.gameObject, "oncomplete", "onShowStageBeginPhase1Ended"));
    }

    public void onShowStageBeginPhase1Ended()
    {
        iTween.MoveTo(imageStageBegin.gameObject, iTween.Hash("x", Screen.width - UI_INIT_POS_X, "easeType", "easeInOutExpo", "oncompletetarget", this.gameObject, "oncomplete", "onShowStageBeginPhase2Ended"));
    }

    public void onShowStageBeginPhase2Ended()
    {
        this.gameMgr.OnLevelStarted();
    }

    public void ShowStageClear()
    {
        Vector3 imagePos = imageStageClear.transform.position;
        imageStageClear.transform.position = new Vector3(UI_INIT_POS_X, imagePos.y, imagePos.z);
        iTween.MoveTo(imageStageClear.gameObject, iTween.Hash("x", Screen.width / 2, "easeType", "easeInOutExpo", "oncompletetarget", this.gameObject, "oncomplete", "onShowStageClearPhase1Ended"));
    }

    public void onShowStageClearPhase1Ended()
    {
        iTween.MoveTo(imageStageClear.gameObject, iTween.Hash("x", Screen.width - UI_INIT_POS_X, "easeType", "easeInOutExpo", "oncompletetarget", this.gameObject, "oncomplete", "onShowStageClearPhase2Ended"));
    }

    public void onShowStageClearPhase2Ended()
    {
        this.gameMgr.OnLevelEnded();
    }
}
