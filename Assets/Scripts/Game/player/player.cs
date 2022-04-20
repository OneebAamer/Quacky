using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class player : MonoBehaviour
{
    public TMP_Text score_counter;
    public TMP_Text endscore_counter;
    private Rigidbody2D rb;
    public GameObject pausemenu;
    public GameObject MenuButtons;
    public GameObject endmenuscreen;
    public TMP_Text highscore;
    public Slider hungerbar;
    string gameId = "4178765";
    bool testMode = false;
    public GameObject extrabutton;
    // Start is called before the first frame update
    void Start()
    {
        score_counter.text = "SCORE: " + PlayerPrefs.GetInt("points");
        if (PlayerPrefs.GetInt("points") > 0)
        {
            extrabutton.SetActive(false);
        }
        Advertisement.Initialize(gameId, testMode);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausemenu.activeSelf == false)
            {
                pausemenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pausemenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "seed")
        {
            Destroy(collision.collider.gameObject);
            PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points") + 1);
            PlayerPrefs.SetInt("seeds", PlayerPrefs.GetInt("seeds") + 1);
            score_counter.text = "SCORE: " + PlayerPrefs.GetInt("points");
            hungerbar.value = 100;
        }
        if (collision.collider.gameObject.tag == "enemy")
        {
            if(Random.Range(0, 3) == 0)
            {
                ShowInterstitialAd();
            }
            if (PlayerPrefs.GetInt("points") > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("points"));
            }
            endscore_counter.text = "SCORE: " + PlayerPrefs.GetInt("points");
            highscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
            gameObject.SetActive(false);
            hungerbar.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            endmenuscreen.SetActive(true);
            MenuButtons.SetActive(false);
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
