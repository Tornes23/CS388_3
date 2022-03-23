using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public Transform mPos;
    public Image mTutorial;
    public Text mWarning;
    // Start is called before the first frame update
    void Start()
    {
        mWarning.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPlaying()
    {
        DebugLog.DrawDebugText("ImageFound");
        mWarning.gameObject.SetActive(false);
        if(!StaticPlayer.GetSeenImage())
        {
            StaticPlayer.SetSeenImage(true);
            LeanTween.alpha(mTutorial.rectTransform, 0.0F, 1.0F).setEase(LeanTweenType.linear);
        }

        mPos.position += new Vector3(0,10,0);
    }

    public void FocusLost()
    {

        mWarning.gameObject.SetActive(true);
        DebugLog.DrawDebugText("ImageLost");
        mPos.position -=new Vector3(0,10,0);
    }
}
