using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BuyCube : MonoBehaviour
{
    public GameObject whichCube, selectBtn, mainCube, text1, text2, text3, text4, text5;
    public GameObject cube1, cube2, cube3, cube4, cube5;
    public Text recording;
    private string recorder;

    void Start()
    {
        recording.text = PlayerPrefs.GetInt("Record1").ToString();
        recorder = recording.text;
    }

    void OnMouseDown()
    {
        int top = Int32.Parse(recorder);
        if (top >= 5){
            cube1.SetActive(true);
            selectBtn.SetActive(true);
            text1.SetActive(false);
            PlayerPrefs.SetString("Cube (1)", "Open");  
        }
        if (top >= 10)
        {
            cube2.SetActive(true);
            selectBtn.SetActive(true);
            text2.SetActive(false);
            PlayerPrefs.SetString("Cube (2)", "Open");
        }
        if (top >= 15)
        {
            cube3.SetActive(true);
            selectBtn.SetActive(true);
            text3.SetActive(false);
            PlayerPrefs.SetString("Cube (3)", "Open");
        }
        if (top >= 20)
        {
            cube4.SetActive(true);
            selectBtn.SetActive(true);
            text4.SetActive(false);
            PlayerPrefs.SetString("Cube (4)", "Open");
        }
        if (top >= 25)
        {
            cube5.SetActive(true);
            selectBtn.SetActive(true);
            text5.SetActive(false);
            PlayerPrefs.SetString("Cube (5)", "Open");
        }
    }
}