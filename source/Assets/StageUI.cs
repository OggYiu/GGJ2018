using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : Singleton<StageUI>
{
    public Image imageStageBegin;
    public Image imageStageClear;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void ShowStageBegin()
    {
        Vector3 imagePos = imageStageBegin.transform.position;
        imageStageBegin.transform.position = new Vector3(-900, imagePos.y, imagePos.z);
        iTween.MoveTo(imageStageBegin.gameObject, iTween.Hash("x", 543.5, "easeType", "easeInOutExpo", "oncompletetarget", this.gameObject, "oncomplete", "onShowStageBeginPhase1Ended"));
    }

    public void onShowStageBeginPhase1Ended()
    {
        iTween.MoveTo(imageStageBegin.gameObject, iTween.Hash("x", 1443.5, "easeType", "easeInOutExpo", "oncompletetarget", this.gameObject, "oncomplete", "onShowStageBeginPhase2Ended"));
    }

    public void onShowStageBeginPhase2Ended()
    {
        GameMgr.Instance.OnLevelStarted();
    }

    public void ShowStageClear()
    {
        Vector3 imagePos = imageStageClear.transform.position;
        imageStageClear.transform.position = new Vector3(-900, imagePos.y, imagePos.z);
        iTween.MoveTo(imageStageClear.gameObject, iTween.Hash("x", 543.5, "easeType", "easeInOutExpo", "oncompletetarget", this.gameObject, "oncomplete", "onShowStageClearPhase1Ended"));
    }

    public void onShowStageClearPhase1Ended()
    {
        iTween.MoveTo(imageStageClear.gameObject, iTween.Hash("x", 1443.5, "easeType", "easeInOutExpo", "oncompletetarget", this.gameObject, "oncomplete", "onShowStageClearPhase2Ended"));
    }

    public void onShowStageClearPhase2Ended()
    {
        GameMgr.Instance.OnLevelEnded();
    }
}
