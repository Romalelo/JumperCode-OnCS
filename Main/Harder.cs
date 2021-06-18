using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour
{
    private bool hard;

    void Update()
    {
        if (CubeJump.count_blocks > 0)
        {
            if (CubeJump.count_blocks % 5 == 0 && !hard)
            {
                Camera.main.GetComponent<Animation>().Play("Harder");
                hard = true;
            }
            else if (CubeJump.count_blocks % 5 != 0 && hard)
            {
                Camera.main.GetComponent<Animation>().Play("Easier");
                hard = false;
            }
        }
    }
}
