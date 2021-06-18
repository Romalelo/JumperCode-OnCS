using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBG : MonoBehaviour
{
    public GameObject whichCube, mainCube, mainCube1, blue, ukraine, blue2;

    void Update()
    {
        //if ((mainCube.GetComponent<Image>().material = blue.GetComponent<MeshRenderer>().material) && (mainCube1.GetComponent<MeshRenderer>().material = blue.GetComponent<MeshRenderer>().material))
            //ukraine.GetComponent<AudioSource>().Play();
    }

    void OnMouseDown()
    {
        if (mainCube1 != null)
        {
            mainCube.GetComponent<Image>().material = GameObject.Find(whichCube.GetComponent<SelectBGNow>().nowCubeBG).GetComponent<MeshRenderer>().material;
            PlayerPrefs.SetString("Now Cube BG", whichCube.GetComponent<SelectBGNow>().nowCubeBG);
        }
        PlayerPrefs.SetString("Now Cube BG", whichCube.GetComponent<SelectBGNow>().nowCubeBG);
        if (whichCube.GetComponent<SelectBGNow>().nowCubeBG == "Cube (3)" && whichCube.GetComponent<SelectCube>().nowCube == "Cube (2)")
        {
            ukraine.GetComponent<AudioSource>().Play();
            print("lol");
        }
    }
}
