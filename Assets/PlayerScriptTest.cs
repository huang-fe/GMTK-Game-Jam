using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using static UnityEngine.ParticleSystem;

public class PlayerScriptTest : MonoBehaviour
{
    public EditLevel editor;
    float timeCount;
    float force = 20f;
    float jumpForce = 50f;
    public Vector3 originalPos = new Vector3(0.5f, 0.5f, 0f);
    bool playing = true;
    int index = 0;
    Rigidbody m_Rigidbody;
    ButtonsPressed[] mvmts;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        mvmts = new ButtonsPressed[] { new ButtonsPressed(false, false, false, 1.5f),
            new ButtonsPressed(false, false, true, 0.1f), 
            new ButtonsPressed(false, true, false, 1.0f),
            new ButtonsPressed(false, false, true, 0.1f),
            new ButtonsPressed(false, true, false, 0.1f),
            new ButtonsPressed(true, false, false, 1.0f),
            new ButtonsPressed(false, false, true, 0.1f),
            new ButtonsPressed(false, true, false, 0.1f),
            new ButtonsPressed(false, false, true, 0.1f),
            new ButtonsPressed(true, false, false, 0.1f),
            new ButtonsPressed(false, false, true, 0.1f),
            new ButtonsPressed(true, false, false, 0.1f)};
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
                    m_Rigidbody.AddForce(0, jumpForce, 0);
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
            if (playing)
            {
                resetLvl(); 
                playing = false;
            } else // playing mode
            {
                index = 0;
                playing = true;
            }
            editor.toggleEdit();
        }
    }

    void resetLvl()
    {
        transform.position = originalPos;
        index = 0;
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
