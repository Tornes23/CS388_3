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

    private Vector2 fp;   //First touch position
    private Vector2 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    // Start is called before the first frame update
    void Start()
    {
        mRB = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0.0f, -1.0f, 0.0f) * 9.8f * 5.0f;
        dragDistance = Screen.height * 5 / 100; //dragDistance is 15% height of the screen
    }

    void Update()
    {
        if (!mThrown)
        {
            NotThrown();
        }
        else
        {
            Thrown();
        }

        
    }

    private void Thrown()
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

    private void NotThrown()
    {
        transform.position = mCamTransfrorm.position;

        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                TouchBegan(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                TouchMoved(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                TouchEnded(touch.position);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                TouchBegan(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                TouchMoved(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                TouchEnded(Input.mousePosition);
            }
        }
        

    }

    private void TouchBegan(Vector2 position)
    {
        fp = position;
        lp = position;
    }

    private void TouchMoved(Vector2 position)
    {
        lp = position;
    }

    private void TouchEnded(Vector2 position)
    {
        lp = position;  //last touch position. Ommitted if you use list

        //Check if drag distance is greater than 20% of the screen height
        if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
        {//It's a drag

            //the vertical movement is greater than the horizontal movement
            if (lp.y > fp.y)  //If the movement was up
            {   //Up swipe
                float power = (Mathf.Abs(lp.y - fp.y) / Screen.height) * 100.0f;
                mRB.velocity = mCamTransfrorm.forward * power;
                DebugLog.DrawDebugText(power.ToString());
                mThrown = true;
            }
            
        }
        else
        {   //It's a tap as the drag distance is less than 20% of the screen height

            DebugLog.DrawDebugText("Tap");
        }
    }
}
