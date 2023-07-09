using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditLevel : MonoBehaviour
{
    public GridSpawner Spawner;
    public Material selectedMaterial;
    int totalCubes;
    int col = 27;
    int row = 45;
    private int index = 0;
    private int last = 0;
    GameObject lastCurrCube = null;
    private bool shiftDragged = false;

    void Start()
    {
        totalCubes = Spawner.allCubes.Count;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shiftDragged = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shiftDragged = false;
        }
        // make selected glow, change back to previous state
        // when dragging, add or remove the current selected obj
        if (Input.GetKeyDown(KeyCode.W))
        {
            if ((index + 1) % col != 0)
            {
                last = index;
                index++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (index >= col)
            {
                last = index;
                index -= col;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (index % 27 != 0)
            {
                last = index;
                index--;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (index < totalCubes - col)
            {
                last = index;
                index += col;
            }
        }
        if (last != index)
        {
            if (!lastCurrCube)
            {
                Destroy(lastCurrCube);
                lastCurrCube = null;
            }
            lastCurrCube = Spawner.currCube(index);
            if (shiftDragged)
            {
                Spawner.editCube(index);
            }
        }
    }
}
