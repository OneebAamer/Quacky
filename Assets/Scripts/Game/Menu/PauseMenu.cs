using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public GameObject options;
    public GameObject menu;
    public AudioMixer audioMixer;
    public void onResume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void onOptions()
    {
        options.SetActive(true);
        menu.SetActive(false);
    }
    public void onOptionsBack()
    {
        options.SetActive(false);
        menu.SetActive(true);
    }
    public void onQuit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("settings"));
    }
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }
    public void setQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }
}
