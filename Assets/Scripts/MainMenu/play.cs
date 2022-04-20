using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class play : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    public void play_game()
    {
        if (!PlayerPrefs.HasKey("colour"))
        {
            PlayerPrefs.SetString("colour", "yellow");
        }
        StartCoroutine(loadLevel("Game"));
    }
    IEnumerator loadLevel(string levelname)
    {
        PlayerPrefs.SetInt("points", 0);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(levelname);
    }
}
