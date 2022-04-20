using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next : MonoBehaviour
{

    public GameObject first_menu;
    public GameObject second_menu;
    public void switch_menus()
    {
        first_menu.SetActive(false);
        second_menu.SetActive(true);
    }
}
