using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMain : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Main")
            Destroy(other.gameObject);
    }
}
