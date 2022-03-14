using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIController : MonoBehaviour
{
    public AudioSource mSound;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = -9.8f * transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    public void FoundFocusCallback()
    {
        mSound.Play();
    }

    public void LostFocusCallback()
    {
        mSound.Stop();
    }
}
