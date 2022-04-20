using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Advertisements;
public class Hunger : MonoBehaviour
{
    public GameObject endscreen;
    public Slider hungerbar;
    public GameObject MenuButtons;
    public TMP_Text highscore;
    public TMP_Text endscore_counter;
    public GameObject duck;
    public GameObject pause;
    public float speed;
    string gameId = "4178765";
    bool testMode = false;
    private void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }
    void Update()
    {
        if (pause.activeSelf == false && gameObject.activeSelf == true) 
        {
            hungerbar.value -= speed * Time.deltaTime;
        }
        if(hungerbar.value == 0)
        {
            if (Random.Range(0, 3) == 0)
            {
                ShowInterstitialAd();
            }
            if (PlayerPrefs.GetInt("points") > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("points"));
            }
            endscore_counter.text = "SCORE: " + PlayerPrefs.GetInt("points");
            highscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
            duck.SetActive(false);
            endscreen.SetActive(true);
            MenuButtons.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("Interstitial_Android");
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
}
