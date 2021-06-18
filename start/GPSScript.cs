using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GPSScript : MonoBehaviour
{
    private const string leader = "CgkIgv6A7eICEAIQBw";
    public GameObject panelConnect, disconnect;
    private const string banner = "ca-app-pub-5278905367193358/9846621544";
    private string appID = "ca-app-pub-5278905367193358~8429011363";

    void Awake()
    {
        BannerView bannerV = new BannerView(banner, AdSize.SmartBanner, AdPosition.Bottom);
        CubeJump.count_blocks = 0;
        MobileAds.Initialize(appID);
        AdRequest request = new AdRequest.Builder().Build();
        bannerV.LoadAd(request);
        print("LOL");
        //Google Play Services
        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        //PlayGamesPlatform.InitializeInstance(config);
        //PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => {
            print(success);
        });
    }

    void Start()
    {
        SceneManager.LoadScene("main");
    }

    public void OnConnectClick()
    {
        Social.localUser.Authenticate((bool succes) =>
        {
            OnConnectionResponce(succes);
        });
    }

    public void OnConnectionResponce(bool authenticated)
    {
        if (authenticated)
        {
            panelConnect.SetActive(true);
        }
        else
        {
            disconnect.SetActive(true);
        }
    }

    public void AcceptFromDisconnect()
    {
        disconnect.SetActive(false);
    }

    public void AcceptFromConnect()
    {
        panelConnect.SetActive(false);
    }

    public void OnApplicationOut()
    {
        //PlayGamesPlatform.Instance.SignOut();
    }
}
