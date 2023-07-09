using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using static UnityEngine.ParticleSystem;

public class PlayerScriptTest : MonoBehaviour
{
    float timeCount;
    float secondsToApplyForce = 5.0f;
    float force = 10f;
    public Vector3 originalPos = new Vector3(0.5f, 0.5f, 0f);
    bool playing = true;
    int index = 0;
    Rigidbody m_Rigidbody;
    ButtonsPressed[] mvmts;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        mvmts = new ButtonsPressed[] { new ButtonsPressed(false, false, true, 1.0f), 
            new ButtonsPressed(false, true, true, 0.5f),
            new ButtonsPressed(true, true, false, 0.5f),
            new ButtonsPressed(true, false, false, 0.5f),
            new ButtonsPressed(true, false, false, 0.5f),
            new ButtonsPressed(true, false, false, 0.5f),
            new ButtonsPressed(true, false, false, 0.5f)};
    }

    void FixedUpdate()
    {
        if (playing)
        {
            timeCount += Time.deltaTime;

            if (timeCount < mvmts[index].sec)
            {
                if (mvmts[index].left)
                {
                    m_Rigidbody.AddForce(-force, 0, 0);
                }
                if (mvmts[index].right)
                {
                    m_Rigidbody.AddForce(force, 0, 0);
                }
                if (mvmts[index].up)
                {
                    m_Rigidbody.AddForce(0, force, 0);
                }
                //Debug.Log(timeCount);
            }
            else
            {
                timeCount = 0;
                index++;
                if (index >= mvmts.Length)
                {
                    index = 0;
                }
            }
        }
    }

    private void Update()
    {
        // nvm cant pause cuz we'd have to turn rigidbody kinematic anyways rip
        if (Input.GetKeyDown(KeyCode.Space)) // editing mode
        {
            resetLvl();
        }
    }

    void resetLvl()
    {
        transform.position = originalPos;
        // reset index too
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
