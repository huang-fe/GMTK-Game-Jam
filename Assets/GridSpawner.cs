using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    // Spawns a grid of cubes of same size with colliders and 

    private bool drag = false;
    private bool adding = true;
    private GameObject[] add;
    private GameObject[] remove;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            drag = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            drag = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == )
    }
}
