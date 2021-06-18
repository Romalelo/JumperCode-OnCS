using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightMatBG : MonoBehaviour
{
    public GameObject[] cubes;

    void Start()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (PlayerPrefs.GetString("Now Cube BG") == cubes[i].name)
            {
                GetComponent<Image>().material = cubes[i].GetComponent<MeshRenderer>().material;
                break;
            }
        }
    }
}
