using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopUnlock : MonoBehaviour
{
    public GameObject text1, text2, text3, text4, text5;
    public Text recording;
    private string recorder;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        recording.text = PlayerPrefs.GetInt("Record").ToString();
        recorder = "10";
        recorder = recording.text;
    }

    void Update()
    {
        int top = Int32.Parse(recorder);
        if (top >= 5)
            text1.SetActive(false);
        if (top >= 10)
            text2.SetActive(false);
        if (top >= 15)
            text3.SetActive(false);
        if (top >= 20)
            text4.SetActive(false);
        if (top >= 25)
            text5.SetActive(false);
    }
}
