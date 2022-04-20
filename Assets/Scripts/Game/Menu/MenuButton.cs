using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject pausemenu;
    public void onPress()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0;
    }
}
