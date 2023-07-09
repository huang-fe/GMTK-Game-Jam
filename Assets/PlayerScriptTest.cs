using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerScriptTest : MonoBehaviour
{
    float timeCount;
    float secondsToApplyForce = 5.0f;
    bool addingForce = true;
    Rigidbody m_Rigidbody;
    //ButtonsPressed[] mvmts;
    ButtonsPressed m;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        m = new ButtonsPressed(false, true, true, secondsToApplyForce);
    }
 
    void FixedUpdate () {
        //if(addingForce) {
        //    timeCount += Time.deltaTime;

        //    if(timeCount < secondsToApplyForce) {
        //        m_Rigidbody.AddForce(20f, 0, 0);
        //        Debug.Log(timeCount);
        //    } else {
        //        timeCount = 0;
        //        addingForce = false;   
        //    }
        //}
        if (addingForce)
        {
            timeCount += Time.deltaTime;

            if (timeCount < m.sec)
            {
                if (m.left)
                {
                    m_Rigidbody.AddForce(-20f, 0, 0);
                }
                if (m.right)
                {
                    m_Rigidbody.AddForce(20f, 0, 0);
                }
                if (m.up)
                {
                    m_Rigidbody.AddForce(0, 20f, 0);
                }
                //Debug.Log(timeCount);
            }
            else
            {
                timeCount = 0;
                addingForce = false; // index++
            }
        }
    }
}

public class ButtonsPressed
{
    public bool left = true;
    public bool right = true;
    public bool up = true;
    public float sec = 0.8f;

    public ButtonsPressed(bool l, bool r, bool u, float s)
    {
        left = l;
        right = r;
        up = u;
        sec = s;
    }
}
