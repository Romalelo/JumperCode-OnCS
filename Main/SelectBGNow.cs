using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBGNow : MonoBehaviour
{
    [HideInInspector]
    public string nowCubeBG;
    public GameObject selectCubeBG, buyCubeBG, mainCubeBG, ukraine;


    void Start()
    {
        if (PlayerPrefs.GetString("Cube") != "Open")
            PlayerPrefs.SetString("Cube", "Open");
    }

    void OnTriggerEnter(Collider other)
    {
        nowCubeBG = other.gameObject.name;
        print(nowCubeBG);
        other.transform.localScale = new Vector3(75f, 75f, 75f);
        if (PlayerPrefs.GetString(other.gameObject.name) == "Open")
        {
            selectCubeBG.SetActive(true);
            buyCubeBG.SetActive(false);
        }
        else
        {
            selectCubeBG.SetActive(false);
            buyCubeBG.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        other.transform.localScale = new Vector3(60f, 60f, 60f);
    }
}
