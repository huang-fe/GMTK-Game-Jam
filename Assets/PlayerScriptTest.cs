using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using static UnityEngine.ParticleSystem;
using TMPro;

public class PlayerScriptTest : MonoBehaviour
{
    public EditLevel editor;
    float timeCount;
    float force = 20f;
    float jumpForce = 20f;
    public Vector3 originalPos = new Vector3(0.5f, 0.5f, 0f);
    bool playing = true;
    int index = 0;
    Rigidbody m_Rigidbody;
    ButtonsPressed[] mvmts;

    public GameObject endUI;
    public TMP_Text mode;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        // right, jump, left, jump, right, jump, left, jump, right, jump left, jump right, right, jump, left, jump, left
        mvmts = new ButtonsPressed[] { new ButtonsPressed(false, false, false, 1.5f),
            new ButtonsPressed(false, true, false, 1.0f), 
            new ButtonsPressed(false, false, true, 0.1f),
            new ButtonsPressed(false, false, false, 1.5f),
            new ButtonsPressed(true, false, true, 0.2f), // left jump
            new ButtonsPressed(true, false, false, 0.5f),
            new ButtonsPressed(false, false, false, 1.5f),
            new ButtonsPressed(false, true, true, 0.3f),
            new ButtonsPressed(false, false, false, 1.5f),
            new ButtonsPressed(true, false, true, 0.3f),
            new ButtonsPressed(false, false, false, 1.5f),
            new ButtonsPressed(false, true, true, 0.3f),
            new ButtonsPressed(false, false, false, 1.5f),
            new ButtonsPressed(true, false, true, 0.3f),
            new ButtonsPressed(false, false, false, 1.5f),
            new ButtonsPressed(false, true, true, 0.3f), // jump right
            new ButtonsPressed(false, false, false, 1.5f),
            new ButtonsPressed(false, true, false, 0.5f),
            new ButtonsPressed(false, false, false, 1.5f),
            new ButtonsPressed(true, false, true, 0.4f), // jump left
            new ButtonsPressed(false, false, false, 1.5f),
            new ButtonsPressed(false, true, true, 0.3f), // jump right
            new ButtonsPressed(false, false, false, 1.0f),
            new ButtonsPressed(false, true, true, 0.3f), // jump right
            new ButtonsPressed(false, false, false, 1.0f),
            new ButtonsPressed(false, true, true, 0.3f), // jump right
            new ButtonsPressed(false, false, false, 1.0f),
            new ButtonsPressed(false, true, true, 0.3f), // jump right
            new ButtonsPressed(false, false, false, 1.0f),
            new ButtonsPressed(false, true, true, 0.3f), // jump right
            new ButtonsPressed(false, false, false, 1.0f)

        };

        mode.text = "Mode: PLAYING";
        //new ButtonsPressed(false, false, true, 0.1f),
        //    new ButtonsPressed(false, true, false, 0.1f),
        //    new ButtonsPressed(false, false, true, 0.1f),
        //    new ButtonsPressed(true, false, false, 0.1f),
        //    new ButtonsPressed(false, false, true, 0.1f)};
}

    void FixedUpdate()
    {
        if (playing && index < mvmts.Length)
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
                //if (index >= mvmts.Length)
                //{
                //    index = 0;
                //}
            }
        }
    }

    private void Update()
    {
        transform.forward = new Vector3(0, 0, 1);
        // nvm cant pause cuz we'd have to turn rigidbody kinematic anyways rip
        if (Input.GetKeyDown(KeyCode.Space)) // editing mode
        {
            Component[] mr = GetComponentsInChildren<MeshRenderer>();
            if (playing)
            {
                mode.text = "Mode: EDITING";
                resetLvl(); 
                playing = false;
                GetComponent<MeshRenderer>().enabled = false;
                foreach (MeshRenderer m in mr)
                    m.enabled = false;
            } else // playing mode
            {
                mode.text = "Mode: PLAYING";
                index = 0;
                playing = true;
                transform.position = originalPos;
                GetComponent<MeshRenderer>().enabled = true;
                foreach (MeshRenderer m in mr)
                    m.enabled = true;
            }
            editor.toggleEdit();
        }
    }

    void resetLvl()
    {
        //transform.position = originalPos;
        //float t = 100.0f;
        //while (t > 0.0f)
        //{
        //    t -= Time.deltaTime;
        //}
        //transform.position = originalPos;
        index = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        endUI.SetActive(true);
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
