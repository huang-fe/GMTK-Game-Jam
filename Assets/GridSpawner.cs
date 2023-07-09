using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject cube; 

    private bool drag = false;
    private bool adding = true;
    private List<GameObject> allCubes = new List<GameObject>();
    private List<GameObject> toAdd;
    private List<GameObject> toRemove;
    private List<GameObject> visibleCubes;

    void Start()
    {
        // spawn all grids. first cube at 0, 0, 0. 0 to 21.5, 0 to 13.75, 43 across, 
        for (float x = 0; x < 21.5; x+=0.5f)
        {
            for (float y = 0; y < 13.5; y+=0.5f)
            {
                GameObject o = Instantiate(cube, new Vector3(x, y, 0), Quaternion.identity);
                allCubes.Add(o);
            }
        }
        Debug.Log(allCubes.Count);
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    drag = true;
        //}
        //if (Input.GetMouseButtonUp(0)) // end drag
        //{
        //    drag = false;
        //    // add or remove all obj in lists, clear lists
        //    if (toAdd.Count > 0)
        //    {
        //        foreach (GameObject go in toAdd) // display all cubes to add
        //        {
        //            go.GetComponent<MeshRenderer>().enabled = true;
        //        }
        //        toAdd.Clear();
        //    }
        //    if (toRemove.Count > 0)
        //    {
        //        foreach (GameObject go in toRemove) // display all cubes to add
        //        {
        //            go.GetComponent<MeshRenderer>().enabled = false;
        //        }
        //        toRemove.Clear();
        //    }
        //}
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "grid" && drag)
    //    {
    //        if (adding)
    //        {
    //            toAdd.Add(collision.gameObject);
    //        } else
    //        {
    //            toRemove.Add(collision.gameObject);
    //        }

    //    }
    //}
}
