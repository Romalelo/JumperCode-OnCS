using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class Buttons : MonoBehaviour
{
    public GameObject shopBG, scrollObj, pause_screen, pause_button, blocksShop, BGShop, playTxt, buttons, BGShopTxt, blocksShopTxt, BGShopBG, detectClicks, shopForBG, notAvialable, imagesOfBG, select;
    public GameObject settings, audios, soundOn, soundOff, restart, mainCube, play, retry, pauseSettings, close, pauseClose, loseButtons, camera;
    public Text recording;
    public ScriptableObject rightMath;
    private string recorder;
    private int cheat;
    private int delete;
    private bool already;
    private int ads = 0;
    private bool adDestroy;
    //private InterstitialAd ad = new InterstitialAd(video);

    void Start()
    {
        if (PlayerPrefs.GetInt("Sounds") == 1)
        {
            audios.SetActive(false);
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Sounds") == 0 )
        {
            audios.SetActive(true);
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void OnMouseUpAsButton()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        switch (gameObject.name)
        {
            case "Share":
                Application.OpenURL("https://vk.com/romalelo");
                break;
            case "Retry":
                SceneManager.LoadScene("main");
                Time.timeScale = 1;
                PlayerPrefs.SetInt("restart", 1);
                break;
            case "Restart":
                SceneManager.LoadScene("main");
                Time.timeScale = 1;
                PlayerPrefs.SetInt("restart", 1);
                break;
            case "Shop":
                if (PlayerPrefs.GetInt("delete") != 1)
                {
                    //PlayerPrefs.DeleteAll();
                    PlayerPrefs.SetInt("delete", 1);
                }
                if (PlayerPrefs.GetInt("Already") == 1)
                {
                    already = false;
                }
                if (!already)
                {
                    BGShopTxt.SetActive(true);
                    blocksShopTxt.SetActive(true);
                    blocksShop.SetActive(true);
                    BGShop.SetActive(true);
                    BGShopTxt.GetComponent<Animation>().Play("BackgroundShop");
                    blocksShopTxt.GetComponent<Animation>().Play("BlocksShop");
                    blocksShop.GetComponent<Animation>().Play("Block Shop");
                    BGShop.GetComponent<Animation>().Play("Bg Shop");
                    already = true;
                    PlayerPrefs.SetInt("Already", 0);
                    break;
                }
                if (already)
                {
                    BGShopTxt.SetActive(false);
                    blocksShopTxt.SetActive(false);
                    blocksShop.SetActive(false);
                    BGShop.SetActive(false);
                    already = false;
                    playTxt.SetActive(true);
                    PlayerPrefs.SetInt("Already", 1);
                    break;
                }
                break;
            case "Blocks Shop":
                shopBG.SetActive(true);
                blocksShop.SetActive(false);
                BGShop.SetActive(false);
                buttons.SetActive(false);
                BGShopTxt.SetActive(false);
                blocksShopTxt.SetActive(false);
                break;
            case "BG Shop":
                BGShopBG.SetActive(true);
                blocksShop.SetActive(false);
                BGShop.SetActive(false);
                buttons.SetActive(false);
                BGShopTxt.SetActive(false);
                blocksShopTxt.SetActive(false);
                detectClicks.SetActive(false);
                shopForBG.SetActive(true);
                break;
            case "Close":
                settings.SetActive(false);
                restart.SetActive(true);
                retry.SetActive(true);
                play.SetActive(true);
                pauseSettings.SetActive(true);
                loseButtons.SetActive(true);
                PlayerPrefs.SetInt("Already", 1);
                blocksShop.SetActive(false);
                BGShop.SetActive(false);
                if (mainCube != null)
                {
                    //playTxt.SetActive(true);
                }
                shopBG.SetActive(false);
                buttons.SetActive(true);
                BGShopBG.SetActive(false);
                detectClicks.SetActive(true);
                shopForBG.SetActive(false);
                //notAvialable.SetActive(false);
                break;
            case "Play Button":
                pause_screen.SetActive(false);
                pause_button.SetActive(true);
                Time.timeScale = 1;
                break;
            case "Pause Button":
                pause_screen.SetActive(true);
                pause_button.SetActive(false);
                Time.timeScale = 0;
                break;
            case "Cheat":
                cheat++;
                if (cheat >= 10)
                {
                    PlayerPrefs.SetInt("Record1", 25);
                    recorder = recording.text;
                    int top = Int32.Parse(recorder);
                }
                break;
            case "Settings":
                settings.SetActive(true);
                detectClicks.SetActive(false);
                buttons.SetActive(false);
                restart.SetActive(false);
                BGShopTxt.SetActive(false);
                blocksShopTxt.SetActive(false);
                blocksShop.SetActive(false);
                BGShop.SetActive(false);
                loseButtons.SetActive(false);
                break;
            case "RetrySettings":
                settings.SetActive(true);
                detectClicks.SetActive(false);
                restart.SetActive(false);
                loseButtons.SetActive(false);
                break;
            case "SoundOn":
                audios.SetActive(false);
                soundOn.SetActive(false);
                soundOff.SetActive(true);
                PlayerPrefs.SetInt("Sounds", 1);
                break;
            case "SoundOff":
                audios.SetActive(true);
                soundOn.SetActive(true);
                soundOff.SetActive(false);
                PlayerPrefs.SetInt("Sounds", 0);
                break;
            case "PauseSettings":
                pauseSettings.SetActive(false);
                settings.SetActive(true);
                play.SetActive(false);
                retry.SetActive(false);
                close.SetActive(false);
                pauseClose.SetActive(true);
                break;
            case "PauseClose":
                blocksShop.SetActive(false);
                BGShop.SetActive(false);
                shopBG.SetActive(false);
                buttons.SetActive(true);
                BGShopBG.SetActive(false);
                detectClicks.SetActive(true);
                shopForBG.SetActive(false);
                settings.SetActive(false);
                restart.SetActive(true);
                retry.SetActive(true);
                play.SetActive(true);
                pauseSettings.SetActive(true);
                pauseClose.SetActive(false);
                close.SetActive(true);
                break;
            case "PauseCloser":
                detectClicks.SetActive(true);
                settings.SetActive(false);
                restart.SetActive(true);
                retry.SetActive(true);
                play.SetActive(true);
                pauseSettings.SetActive(true);
                pauseClose.SetActive(false);
                close.SetActive(false);
                break;
            case "Achivments":
                Social.ShowLeaderboardUI();
                break;
            case "Play":
                camera.GetComponent<Animation>().Play("Play");
                break;
            case "BackToMain":
                camera.GetComponent<Animation>().Play("BackMain");
                break;
            case "SimpleMode":
                SceneManager.LoadScene(1);
                mainCube.GetComponent<RightMat>().enabled = false;
                break;
            case "TimeMode":
                SceneManager.LoadScene(2);
                break;
        }
    }
}
