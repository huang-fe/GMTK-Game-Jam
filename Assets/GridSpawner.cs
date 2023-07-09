using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject cube;
    public Material selectedMaterial;
    [HideInInspector] public List<GameObject> allCubes = new List<GameObject>();

    void Awake()
    {
        // spawn all grids. first cube at 0, 0, 0. 27x45
        for (float x = 0; x < 22.5f; x+=0.5f)
        {
            for (float y = 0; y < 13.5f; y+=0.5f)
            {
                GameObject o = Instantiate(cube, new Vector3(x, y, 0), Quaternion.identity);
                allCubes.Add(o);
                o.SetActive(false);
            }
        }
        Debug.Log(allCubes.Count);
    }

    // displays curr cube
    public GameObject currCube(int index)
    {
        GameObject curr = Instantiate(allCubes[index]);
        curr.GetComponent<MeshRenderer>().material = selectedMaterial; 
        curr.SetActive(true);
        return curr;
    }

    public void editCube(int index) 
    {
        allCubes[index].SetActive(!allCubes[index].activeSelf);
        //allCubes[index].GetComponent<MeshRenderer>().enabled = true;
    }
}
