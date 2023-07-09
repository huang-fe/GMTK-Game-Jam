using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditLevel : MonoBehaviour
{
    public GridSpawner Spawner;
    int totalCubes;
    int col = 27;
    int row = 45;
    private int index = 0;
    private int last = 0;
    GameObject lastCurrCube = null;
    private bool shiftDragged = false;
    bool allowEdit = false;

    void Start()
    {
        totalCubes = Spawner.allCubes.Count;
    }

    public void toggleEdit()
    {
        allowEdit = !allowEdit;
    }

    void Update()
    {
        // make selected glow, change back to previous state
        // when dragging, add or remove the current selected obj
        if (allowEdit)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if ((index + 1) % col != 0)
                {
                    last = index;
                    index++;

                    Debug.Log("index : " + index + " last = " + last);
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (index >= col)
                {
                    last = index;
                    index -= col;

                    Debug.Log("index : " + index + " last = " + last);
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (index % 27 != 0)
                {
                    last = index;
                    index--;

                    Debug.Log("index : " + index + " last = " + last);
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (index < totalCubes - col)
                {
                    last = index;
                    index += col;

                    Debug.Log("index : " + index + " last = " + last);
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                shiftDragged = true;
                Spawner.editCube(index);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                shiftDragged = false;
            }

            if (last != index)
            {
                Debug.Log("index : " + index + " last = " + last);
                if (lastCurrCube != null)
                {
                    Debug.Log("last " + lastCurrCube.ToString());
                    Destroy(lastCurrCube);

                }
                lastCurrCube = Spawner.currCube(index);
                if (shiftDragged)
                {
                    Spawner.editCube(index);
                }
                last = index;
            }
        }
    }
}
