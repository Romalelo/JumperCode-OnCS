using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryText : MonoBehaviour
{

    void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }
    void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
