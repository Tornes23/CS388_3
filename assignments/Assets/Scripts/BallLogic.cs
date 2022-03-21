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

    // Start is called before the first frame update
    void Start()
    {
        mRB = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0.0f, -1.0f, 0.0f) * 9.8f * 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mThrown)
        {
            transform.position = mCamTransfrorm.position;

            if (Input.GetMouseButtonDown(0))
            {
                mThrown = true;
                mRB.velocity = mCamTransfrorm.forward * 50.0f;
            }
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

        
    }
}
