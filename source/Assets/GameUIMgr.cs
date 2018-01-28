using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIMgr : MonoBehaviour
{
    public enum GotHitType
    {
        MINUS_10,
        MINUS_20,
        MINUS_30,
    }
    public enum GotScoreType
    {
        SCORE_10,
        SCORE_20,
        SCORE_30,
    }

    public GameObject[] prefabGotHitImages;
    public GameObject[] prefabGotScoreImages;
    public Image[] currentHeightImages;
    public Image[] targetHeightImages;
    public Sprite[] heightSprites;
    private Parcel parcel;

    // Use this for initialization
    void Start () {
        parcel = FindObjectOfType<Parcel>();

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void ShowGotHit(GotHitType type)
    {
        GameObject targetImage = GameObject.Instantiate(prefabGotHitImages[(int)type]);
        iTween.MoveBy(targetImage, iTween.Hash("y", 1, "easeType", "easeInOutExpo", "oncompletetarget", this.gameObject));
        targetImage.transform.position = new Vector3(this.parcel.transform.position.x, this.parcel.transform.position.y, -9);
        DestroyObject(targetImage, 1.0f);
    }

    public void ShowGotScore(GotScoreType type, GameObject target)
    {
        GameObject targetImage = GameObject.Instantiate(prefabGotScoreImages[(int)type]);
        iTween.MoveBy(targetImage, iTween.Hash("y", 1, "easeType", "easeInOutExpo", "oncompletetarget", this.gameObject));
        targetImage.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -9);
        DestroyObject(targetImage, 1.0f);
    }

    public void SetCurrentHeight(int height)
    {
        Image image10000 = currentHeightImages[4];
        Image image1000 = currentHeightImages[3];
        Image image100 = currentHeightImages[2];
        Image image10 = currentHeightImages[1];
        Image image1 = currentHeightImages[0];

        int digit1 = height % 10;
        int digit2 = (int)((height % 100) / 10);
        int digit3 = (int)((height % 1000) / 100);
        int digit4 = (int)((height % 10000) / 1000);
        int digit5 = (int)((height % 100000) / 10000);

        if (digit1 >= 0 && digit2 >= 0 && digit3 >= 0 && digit4 >= 0)
        {
            image10000.sprite = heightSprites[digit5];
            image1000.sprite = heightSprites[digit4];
            image100.sprite = heightSprites[digit3];
            image10.sprite = heightSprites[digit2];
            image1.sprite = heightSprites[digit1];
        }
    }

    public void SetTargetHeight(int height)
    {
        Image image10000 = targetHeightImages[4];
        Image image1000 = targetHeightImages[3];
        Image image100 = targetHeightImages[2];
        Image image10 = targetHeightImages[1];
        Image image1 = targetHeightImages[0];

        int digit1 = height % 10;
        int digit2 = (int)((height % 100) / 10);
        int digit3 = (int)((height % 1000) / 100);
        int digit4 = (int)((height % 10000) / 1000);
        int digit5 = (int)((height % 100000) / 10000);

        if (digit1 >= 0 && digit2 >= 0 && digit3 >= 0 && digit4 >= 0)
        {
            image10000.sprite = heightSprites[digit5];
            image1000.sprite = heightSprites[digit4];
            image100.sprite = heightSprites[digit3];
            image10.sprite = heightSprites[digit2];
            image1.sprite = heightSprites[digit1];
        }
    }
}
