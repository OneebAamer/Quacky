using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class settings : MonoBehaviour
{
    public List<Button> colour_selector;
    public List<Button> buy_buttons;
    public TMP_Text seedcounter; 
    private void Start()
    {
        PlayerPrefs.SetInt("yellow", 1);
    }
    private void Update()
    {
        seedcounter.text = "SEEDS: " + PlayerPrefs.GetInt("seeds");
        for (int i = 0; i < colour_selector.Capacity; i++)
        {
            if (PlayerPrefs.HasKey(colour_selector[i].transform.parent.name))
            {
                colour_selector[i].interactable = true;
                buy_buttons[i].interactable = false;
            }
            else
            {
                colour_selector[i].interactable = false;
            }
        }
    }
    public void onBuy(Button button)
    {
        if (PlayerPrefs.GetInt("seeds") >= 400)
        {
            PlayerPrefs.SetInt(button.transform.parent.name, 1);
            PlayerPrefs.SetInt("seeds", PlayerPrefs.GetInt("seeds") - 400);
            button.interactable = false;
        }
    }
}
