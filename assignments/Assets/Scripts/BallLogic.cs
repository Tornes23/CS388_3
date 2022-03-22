using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    public Transform mCamTransfrorm;
    private Rigidbody mRB;

    private bool mThrown = false;
    private float mTimer = 0.0f;
    public float mMaxTime = 5.0f;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    // Start is called before the first frame update
    void Start()
    {
        mRB = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0.0f, -1.0f, 0.0f) * 9.8f * 5.0f;
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
    }

    void Update()
    {
        if (!mThrown)
        {
            transform.position = mCamTransfrorm.position;

            //if (Input.GetMouseButtonDown(0))
            //{
            //    mThrown = true;
            //    mRB.velocity = mCamTransfrorm.forward * 50.0f;
            //}
        }
        else
        {
            if (mTimer < mMaxTime)
            {
                mTimer += Time.deltaTime;
            }
            else
            {
                mTimer = 0.0f;
                mThrown = false;
            }
        }

        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Right Swipe");
                            DebugLog.DrawDebugText("Right Swipe");
                        }
                        else
                        {   //Left swipe
                            Debug.Log("Left Swipe");
                            DebugLog.DrawDebugText("Left Swipe");
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                            DebugLog.DrawDebugText("Up Swipe");
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                            DebugLog.DrawDebugText("Down Swipe");
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                    DebugLog.DrawDebugText("Tap");
                }
            }
        }
    }
}
