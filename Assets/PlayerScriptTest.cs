using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptTest : MonoBehaviour
{
    float timeCount;
    float secondsToApplyForce = 5.0f;
    bool addingForce = true;
    Rigidbody m_Rigidbody;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
    }
 
    void FixedUpdate () {
        if(addingForce) {
            timeCount += Time.deltaTime;
    
            if(timeCount < secondsToApplyForce) {
                m_Rigidbody.AddForce(20f, 0, 0);
                Debug.Log(timeCount);
            } else {
                timeCount = 0;
                addingForce = false;   
            }
        }
    }
}

public class ButtonsPressed
{
    public bool left = true;
    public bool right = true;
    public bool jump = true;
}
