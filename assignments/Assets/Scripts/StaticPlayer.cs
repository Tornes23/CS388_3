using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class StaticPlayer
{
    static private Transform mPlayer;
    static private bool mSeenImage = false;

    static public Transform GetPlayer()
    {
        if (mPlayer == null)
        {
            mPlayer = GameObject.Find("Player").transform;
        }
        return mPlayer;
    }
    static public void SetSeenImage(bool value) { mSeenImage = value; }
}