using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    public Text mScore;
    public Text mWinText;
    public int WinCondition = 3;
    // Start is called before the first frame update
    void Start()
    {
        mScore.text = "Score: " + StaticPlayer.GetScore().ToString();
        mWinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!StaticPlayer.GetPlaying())
        {
            mScore.gameObject.SetActive(false);
            mWinText.gameObject.SetActive(false);
            return;
        }
        if (StaticPlayer.GetScore() == WinCondition)
        {
            mWinText.gameObject.SetActive(true);
        }

        if(StaticPlayer.GetPlaying())
            mScore.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Canasta"))
        {
            StaticPlayer.IncrementScore();
            mScore.text = "Score: " + StaticPlayer.GetScore().ToString();
        }
    }
}
