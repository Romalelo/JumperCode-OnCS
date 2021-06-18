using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds.Api;

public class Score : MonoBehaviour
{
    public Text record, record1;
    private Text txt;
    private bool gameStart;
    private const string ach1 = "CgkIgv6A7eICEAIQAQ";
    private const string ach2 = "CgkIgv6A7eICEAIQAg";
    private const string ach3 = "CgkIgv6A7eICEAIQAw";
    private const string ach4 = "CgkIgv6A7eICEAIQBA";
    private const string ach5 = "CgkIgv6A7eICEAIQBQ";
    private const string ach6 = "CgkIgv6A7eICEAIQBg";
    private const string leader = "CgkIgv6A7eICEAIQBw";
    private const string banner = "ca-app-pub-5278905367193358/9846621544";
    private string appID = "ca-app-pub-5278905367193358~8429011363";

    void Awake()
    {
            BannerView bannerV = new BannerView(banner, AdSize.SmartBanner, AdPosition.Bottom);
            txt = GetComponent<Text>();
            CubeJump.count_blocks = 0;
            MobileAds.Initialize(appID);
            AdRequest request = new AdRequest.Builder().Build();
            bannerV.LoadAd(request);
            //print("LOL");
    }


    private void GetTheAch(string id)
    {
        Social.ReportProgress(id, 100f, (bool succes) =>
        {
            if (succes) print("Nice");
        });
    }

    void Update()
    {
        record.text = "BEST: " + PlayerPrefs.GetInt("Record").ToString();
        record1.text = PlayerPrefs.GetInt("Record1").ToString();
        if (txt.text == "0")
            gameStart = true;
        if (gameStart)
        {
            txt.text = CubeJump.count_blocks.ToString();
            if (PlayerPrefs.GetInt("Record") < CubeJump.count_blocks)
            {
                Social.ReportScore(CubeJump.count_blocks, leader, (bool succes)=>
                {
                
                });
                PlayerPrefs.SetInt("Record", CubeJump.count_blocks);
                if (PlayerPrefs.GetInt("Record1") < CubeJump.count_blocks)
                    PlayerPrefs.SetInt("Record1", CubeJump.count_blocks);
                record.text = "BEST: " + PlayerPrefs.GetInt("Record").ToString();
                record1.text = PlayerPrefs.GetInt("Record1").ToString();
            }
        }
    /*    if (PlayerPrefs.GetInt("Record1") >= 5)
        {
            Social.ReportProgress("CgkIgv6A7eICEAIQAQ", 100f, (bool succes) =>
            {
                if (succes) print("Nice");
            });
        }
        if (PlayerPrefs.GetInt("Record1") >= 10)
        {
            Social.ReportProgress("CgkIgv6A7eICEAIQAg", 100f, (bool succes) =>
            {
                if (succes) print("Nice");
            });
        }
        if (PlayerPrefs.GetInt("Record1") >= 15)
        {
            Social.ReportProgress("CgkIgv6A7eICEAIQAw", 100f, (bool succes) =>
            {
                if (succes) print("Nice");
            });
        }
        if (PlayerPrefs.GetInt("Record1") >= 20)
        {
            Social.ReportProgress("CgkIgv6A7eICEAIQBA", 100f, (bool succes) =>
            {
                if (succes) print("Nice");
            });
        }
        if (PlayerPrefs.GetInt("Record1") >= 25)
        {
            Social.ReportProgress("CgkIgv6A7eICEAIQBQ", 100f, (bool succes) =>
            {
                if (succes) print("Nice");
            });
        }
        if (PlayerPrefs.GetInt("Record1") >= 50)
        {
            Social.ReportProgress("CgkIgv6A7eICEAIQBg", 100f, (bool succes) =>
            {
                if (succes) print("Nice");
            });
        }*/
    }
}
