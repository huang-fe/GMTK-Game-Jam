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

    // Start is called before the first frame update
    void Start()
    {
        totalCubes = Spawner.allCubes.Count;
        Spawner.onEditMode();
    }

    // Update is called once per frame
    void Update()
    {
        // make selected glow, change back to previous state
        // when dragging, add or remove the current selected obj
        if (Input.GetKeyDown(KeyCode.W))
        {
            if ((index + 1) % col != 0)
            {
                index++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (index >= col)
            {
                index -= col;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (index % 27 != 0)
            {
                index--;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (index < totalCubes - col)
            {
                index += col;
            }
        }
        Spawner.selectCube(index);
    }
}
