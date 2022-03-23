using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class StaticPlayer
{
    static private Transform mPlayer;
    static private bool mSeenImage = false;
    static private bool mPlaying = false;
    static private int mScore = 0;

    static public Transform GetPlayer()
    {
        if (mPlayer == null)
        {
            mPlayer = GameObject.Find("Player").transform;
        }
        return mPlayer;
    }
    static public void SetSeenImage(bool value) { mSeenImage = value; }
    static public bool GetSeenImage() { return mSeenImage; }
    static public void SetPlaying(bool value) { mPlaying = value; }
    static public bool GetPlaying() { return mPlaying; }
    static public int GetScore() { return mScore; }
    static public void IncrementScore() { mScore++; }
}