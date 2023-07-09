using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject cube; 

    //private bool drag = false;
    //private bool adding = true;
    [HideInInspector] public List<GameObject> allCubes = new List<GameObject>();
    //private List<GameObject> toAdd;
    //private List<GameObject> toRemove;

    void Awake()
    {
        // spawn all grids. first cube at 0, 0, 0. 27x45
        for (float x = 0; x < 22.5f; x+=0.5f)
        {
            for (float y = 0; y < 13.5f; y+=0.5f)
            {
                GameObject o = Instantiate(cube, new Vector3(x, y, 0), Quaternion.identity);
                allCubes.Add(o);
                o.GetComponent<MeshRenderer>().enabled = false; // invisible at start
                o.SetActive(false);
            }
        }
        Debug.Log(allCubes.Count);
    }

    void hideAll()
    {
        foreach (GameObject o in allCubes)
        {
            o.SetActive(false);
        }
    }

    public void onEditMode()
    {
        foreach (GameObject o in allCubes)
        {
            o.SetActive(true);
        }
    }

    // assumes is active before calling
    public void selectCube(int index)
    {
        allCubes[index].GetComponent<MeshRenderer>().enabled = true;
    }

    //void Update()
    //{
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
    //}

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
