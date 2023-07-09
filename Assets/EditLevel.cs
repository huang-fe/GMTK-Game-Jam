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
    private bool lastWasActive = false;
    private bool shiftDragged = false;

    // Start is called before the first frame update
    void Start()
    {
        totalCubes = Spawner.allCubes.Count;
    }

    // Update is called once per frame
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
        Spawner.currCube(index);
        if (last != index) // reset last
        {
            
        }
    }
}
