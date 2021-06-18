using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{
    private bool moved = true;
    private Vector3 target;

    void Start()
    {
        target = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        if (CubeJump.nextBlock)
        {
            if (transform.position != target)
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 10f);
            else if (transform.position == target && !moved)
            {
                moved = true;
                target = new Vector3(transform.position.x - 2.25f, transform.position.y + 1.5f, transform.position.z);
                CubeJump.jump = false;
            }
            if (CubeJump.jump)
                moved = false;
        }
    }
}

