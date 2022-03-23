using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public Transform mPos;
    public Image mTutorial;
    public Text mWarning;
    public Text mWarning2;
    // Start is called before the first frame update
    void Start()
    {
        mWarning.color = new Color(1, 1, 1, 0);
        mWarning2.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPlaying()
    {
        //StaticPlayer.SetPlaying(true);
        //mWarning.color = new Color(1, 1, 1, 0);
        //mWarning2.color = new Color(1, 1, 1, 0);
        //
        //if (!StaticPlayer.GetSeenImage())
        //{
        //    StaticPlayer.SetSeenImage(true);
        //    LeanTween.alpha(mTutorial.rectTransform, 0.0F, 1.0F).setEase(LeanTweenType.linear);
        //    mWarning.color = new Color(1, 1, 1, 0);
        //    mWarning2.color = new Color(1, 1, 1, 0);
        //}
        //
        //mPos.position += new Vector3(0,10,0);
    }

    public void FocusLost()
    {
        //StaticPlayer.SetPlaying(false);
        //mWarning.color = new Color(1, 1, 1, 1);
        //mWarning2.color = new Color(1, 1, 1, 1);
        //mPos.position -=new Vector3(0,10,0);
    }
}
