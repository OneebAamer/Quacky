using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class button_selected : MonoBehaviour
{
    public List<Button> buttons;
    public void onColourPress(Button button)
    {
        PlayerPrefs.SetString("colour", button.transform.parent.name);
        button.Select();
    }
    public void onDifficultyPress(Button button)
    {
        PlayerPrefs.SetString("difficulty", button.transform.parent.name);
        button.Select();
    }
}
