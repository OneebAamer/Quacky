using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ExtraSeeds : MonoBehaviour, IUnityAdsListener
{
    string gameId = "4178765";
    bool testMode = false;
    Button myButton;
    string mySurfacingId = "Rewarded_Android";
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.interactable = Advertisement.IsReady(mySurfacingId);
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }
    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(mySurfacingId);
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string surfacingId)
    {
        myButton.interactable = true;
    }

    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished && surfacingId == "Rewarded_Android")
        {
            PlayerPrefs.SetInt("seeds", PlayerPrefs.GetInt("seeds") + 25);
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("skipped");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }
    public void OnUnityAdsDidError(string surfacingId)
    {
        Debug.Log("error");
    }
    public void OnUnityAdsDidStart(string surfacingId)
    {
        Debug.Log("started");
    }
    IEnumerator Retry(string surfacingId)
    {
        yield return new WaitForSeconds(0.5f);
        if (surfacingId == mySurfacingId)
        {
            myButton.interactable = true;
        }
        else
        {
            Retry(surfacingId);
        }
    }
}
