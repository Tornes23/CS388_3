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
        if (!StaticPlayer.GetPlaying())
        {
            mScore.color = new Color(1, 1, 1, 0);
            mWinText.gameObject.SetActive(false);
        }

        mScore.text = "Score: " + StaticPlayer.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.K))
            StaticPlayer.IncrementScore();

        if (!StaticPlayer.GetPlaying())
        {
            mScore.color = new Color(1, 1, 1, 0);
            mWinText.color = new Color(1, 1, 1, 0);
            return;
        }
        if (StaticPlayer.GetScore() == WinCondition)
        {
            mWinText.color = new Color(1, 1, 1, 1);
        }

        mScore.color = new Color(1, 1, 1, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Pelota"))
        {
            StaticPlayer.IncrementScore();
            mScore.text = "Score: " + StaticPlayer.GetScore().ToString();
        }
    }
}
