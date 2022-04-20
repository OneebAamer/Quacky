using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ExtraLife : MonoBehaviour, IUnityAdsListener
{
    public GameObject button;
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
        // If the ready Ad Unit or legacy Placement is rewarded, activate the button: 
        if (surfacingId == mySurfacingId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished && surfacingId == "Rewarded_Android")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
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
}
