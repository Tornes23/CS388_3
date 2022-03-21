using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class FadeToLevel : MonoBehaviour
{
    public string mNextLevel;
    public float mShowTime;
    float mTimer = 0.0F;
    bool mbFadeFinished = false;
    public Image mImage;
    public bool mbToOne;
    // Start is called before the first frame update
    void Start()
    {
        StartFade(false);
    }
    private void Update()
    {
        if(mbFadeFinished && mShowTime >= 0.0F)
        {
            mTimer += Time.deltaTime;
            if (mTimer >= mShowTime)
                StartFade(true);
        }
    }
    // Update is called once per frame
    void FadeFinished()
    {
        mbFadeFinished = true;

        if(mShowTime < 0.0F)
            mImage.gameObject.SetActive(false);
    }

    public void StartFade(bool reverse)
    {
        if (reverse)
        {
            mImage.gameObject.SetActive(true);
            LeanTween.alpha(mImage.rectTransform, mbToOne ? 0.0F : 1.0F, 1.0F).setEase(LeanTweenType.linear).setOnComplete(ChangeLevel);
        }
        else    
            LeanTween.alpha(mImage.rectTransform, mbToOne ? 1.0F : 0.0F, 1.0F).setEase(LeanTweenType.linear).setOnComplete(FadeFinished);
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(mNextLevel);
    }
}
