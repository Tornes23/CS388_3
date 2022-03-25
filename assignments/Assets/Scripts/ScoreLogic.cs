using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    public TextMesh mScore;
    public Text mWinText;
    public int WinCondition = 3;
    // Start is called before the first frame update
    void Start()
    {
            mWinText.color = new Color(0, 0, 0, 0);
        if (!StaticPlayer.GetPlaying())
        {
            mScore.color = new Color(1, 0, 0, 0);
            mWinText.color = new Color(0, 0, 0, 0);
        }

        mScore.text = StaticPlayer.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.K))
            StaticPlayer.IncrementScore();

        if (!StaticPlayer.GetPlaying())
        {
            mScore.color = new Color(1, 0, 0, 0);
            mWinText.color = new Color(1, 1, 1, 0);
            return;
        }
        if (StaticPlayer.GetScore() == WinCondition)
        {
            mWinText.color = new Color(0, 0, 0, 1);
        }

        mScore.color = new Color(1, 0, 0, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pelota"))
        {
            StaticPlayer.IncrementScore();
            mScore.text = StaticPlayer.GetScore().ToString();
        }
    }
}
