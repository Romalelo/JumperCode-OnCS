using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class DetectClicks : MonoBehaviour {

    public Text playTxt, gameName, record;
    public GameObject buttons, m_cube, platform, spawn_blocks, start_timer, allCubes, starter, restart, pause_button, BGShopTxt, blocksShopTxt, blocksShop, BGShop, smoke;
    public GameObject[] cubes;
    public Rigidbody cube;

    private Vector3 blockPos, target;
    private GameObject blockInst;
    private bool clicked, ad;
    private Collider other;
    private const string banner = "ca-app-pub-5278905367193358/9846621544";
    private string appID = "ca-app-pub-5278905367193358~8429011363";

    void OnMouseDown()
    {
        if (!clicked)
        {
            clicked = true;
            BGShopTxt.SetActive(false);
            blocksShopTxt.SetActive(false);
            BGShop.SetActive(false);
            blocksShop.SetActive(false);
            StartCoroutine(delCubes());
            playTxt.gameObject.SetActive(false);
            restart.SetActive(true);
            record.gameObject.SetActive(true);
            gameName.text = "0";
            buttons.GetComponent<ScrollObj>().speed = -5f;
            buttons.GetComponent<ScrollObj>().checkPos = -200f;
            pause_button.SetActive(true);
            /*BannerView bannerV = new BannerView(banner, AdSize.SmartBanner, AdPosition.Bottom);
            MobileAds.Initialize(appID);
            AdRequest request = new AdRequest.Builder().Build();
            bannerV.LoadAd(request);
            PlayerPrefs.SetInt("deleteAds", 0);
            PlayerPrefs.GetInt("deleteAds" + 1);
            if (PlayerPrefs.GetInt("deleteAds") == 2)
            {
                PlayerPrefs.SetInt("deleteAds", 0);
                bannerV.Destroy();
            }*/
        }
   }

    IEnumerator delCubes()
    {
        blockPos = new Vector3(0f, 0f, 0f);
        blockInst = Instantiate(start_timer, new Vector3(0f, 0f, -9f), Quaternion.identity) as GameObject;
        blockInst.transform.parent = allCubes.transform;
        start_timer.SetActive(true);
        starter.GetComponent<Animation>().Play("Starter");
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(cubes[i]);
        }
        spawn_blocks.GetComponent<SpawnBlocks>().enabled = true;
        m_cube.AddComponent<Rigidbody>();
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1.0f);
        }
    }
}
