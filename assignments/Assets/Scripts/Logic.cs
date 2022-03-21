using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Logic : MonoBehaviour
{
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
        Debug.LogWarning("ImageFound");
        mWarning.gameObject.SetActive(false);
        if(!StaticPlayer.GetSeenImage())
        {
            StaticPlayer.SetSeenImage(true);
            LeanTween.alpha(mTutorial.rectTransform, 0.0F, 1.0F).setEase(LeanTweenType.linear);
        }

        StaticPlayer.GetPlayer().gameObject.SetActive(true);
    }

    public void FocusLost()
    {

        mWarning.gameObject.SetActive(true);
        Debug.LogWarning("ImageLost");
        StaticPlayer.GetPlayer().gameObject.SetActive(false);
    }
}
