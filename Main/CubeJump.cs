using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class CubeJump : MonoBehaviour
{

    public static bool jump, nextBlock=true, spawn=true, lose = false;
    public GameObject mainCube, blocks, retry, buttons, pause, cubes, sound, sound1, detecterClicks;
    public bool animate, jumped, stop=true, stop2=true;
    private float scrath_speed = 0.5f, startTime, yPosCube;
    public static int count_blocks;
    public float speed = 5f;
    private int ads=0;
    private const string banner = "ca-app-pub-5278905367193358/2582413038";
    private const string video = "ca-app-pub-5278905367193358/6915944090";
    private string appID = "ca-app-pub-5278905367193358~8429011363";
    private bool adDestroy;
    //private InterstitialAd ad = new InterstitialAd(video);

    void Start()
    {
        StartCoroutine(canJump());
        jump = false;
        nextBlock = true;
        lose = false;
    }

    void FixedUpdate()
    {
        if (animate && mainCube.transform.localScale.y > 0.4f)
            PressCube(-scrath_speed);
        else if (!animate && mainCube != null)
        {
            if (mainCube.transform.localScale.y < 1f)
                PressCube(scrath_speed * 3f);
            else if (mainCube.transform.localScale.y == 1.5f)
                mainCube.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (mainCube != null)
        {
            if (mainCube.transform.position.y < -5f)
            {
                //Destroy(mainCube, 0.5f);
                lose = true;
            }
        }
        else if (mainCube == null)
            lose = true;
    }

    void Update()
    {
        if (mainCube==null && stop2)
        {
            lose = true;
            stop2 = false;
            pause.SetActive(false);
        }
        if (lose && stop)
        {
            InterstitialAd ad = new InterstitialAd(video);
            PlayerPrefs.SetInt("Ads", PlayerPrefs.GetInt("Ads") + 1);
            print(PlayerPrefs.GetInt("Ads"));
            if (PlayerPrefs.GetInt("Ads") == 3)
            {
                MobileAds.Initialize(appID);
                PlayerPrefs.SetInt("Ads", 0);
                ad = new InterstitialAd(video);
                AdRequest request = new AdRequest.Builder().Build();
                ad.LoadAd(request);
                if (ad.IsLoaded())
                {
                    ad.Show();
                }
            }
            //StartCoroutine(timer());
            blocks.GetComponent<Animation>().Play("FallBlocks");
            retry.GetComponent<Animation>().Play("Retry");
            buttons.GetComponent<Animation>().Play("LoseButtons");
            stop = false;
            pause.SetActive(false);
            sound1.GetComponent<AudioSource>().Play();
            adDestroy = true;

        }
        if (Timer.stop3)
        {
            lose = true;
            Debug.Log("123");
        }
    }

    void OnMouseDown()
    {
            if (mainCube.GetComponent<Rigidbody>() && nextBlock)
            {
                animate = true;
                startTime = Time.time;
                yPosCube = mainCube.transform.localPosition.y;
            }
    }

        void OnMouseUp()
        {
        if (mainCube.GetComponent<Rigidbody>() && nextBlock)
            {
            if (adDestroy)
            {
                //ad.Destroy();
                adDestroy = false;
            }
                animate = false;
                jump = true;
                nextBlock = false;
                float force, diff;
                diff = Time.time - startTime;
                if (diff < 3f)
                    force = 180 * diff;
                else
                    force = 300f;
                if (force < 60f)
                    force = 60f;
                detecterClicks.SetActive(true);
                mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.up * force);
                mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * force);
                StartCoroutine(checkCubePos());
            print("1");
                nextBlock = false;
            spawn = true;
            }
    }

        void PressCube(float force)
        {
            mainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
            mainCube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);
        }

        IEnumerator checkCubePos()
        { 
            yield return new WaitForSeconds(1.0f);
            if (Mathf.Abs(yPosCube-mainCube.transform.localPosition.y)<0.02f && mainCube.GetComponent<Rigidbody>().IsSleeping())
            {
                lose = true;
        }
            else
            {
                while (!mainCube.GetComponent<Rigidbody>().IsSleeping())
                {
                    yield return new WaitForSeconds(0.05f);
                    if (mainCube == null)
                    {
                        lose = true;
                        break;                      
                    }
                }
            }
            if (!lose)
            {
                nextBlock = true;
                count_blocks++;
                sound.GetComponent<AudioSource>().Play();
                mainCube.transform.localPosition = new Vector3(mainCube.transform.localPosition.x, mainCube.transform.localPosition.y, 0f);
                mainCube.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                detecterClicks.SetActive(false);
        }
        }
        IEnumerator canJump()
    {
        while (!mainCube.GetComponent<Rigidbody>())
            yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(0.5f);
        nextBlock = true;
    }

        IEnumerator timer()
        {
        for (int i = 200; i > 0; i--)
        {
            yield return new WaitForSeconds(0.01f);
            cubes.transform.position = Vector3.MoveTowards(cubes.transform.position, new Vector3(cubes.transform.position.x, cubes.transform.position.y - 10f, cubes.transform.position.z), Time.deltaTime * speed);
            if (cubes.transform.position.y < -10f)
                i = 0;
        }
        }
    IEnumerator timer2()
    {
        yield return new WaitForSeconds(0.1f);
    }
}