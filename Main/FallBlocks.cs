using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlocks : MonoBehaviour
{
    public GameObject mainCube, cubes;

    void Update()
    {
        if (mainCube==null)
            cubes.transform.position = Vector3.MoveTowards(cubes.transform.position, new Vector3(cubes.transform.position.x, -10f, cubes.transform.position.z), Time.deltaTime * 2f);
    }
    }
