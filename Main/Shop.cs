using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject detectClicks, allCubes, scrollObj, playTxt, whichCube;


    void OnEnable()
    {
        playTxt.SetActive(false);
        detectClicks.SetActive(false);
        allCubes.SetActive(true);
        scrollObj.SetActive(true);
        whichCube.SetActive(true);
    }

    void OnDisable()
    {
        detectClicks.SetActive(true);
        allCubes.SetActive(false);
        scrollObj.SetActive(false);
        playTxt.SetActive(true);
        whichCube.SetActive(false);
    }
}
