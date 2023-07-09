using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
