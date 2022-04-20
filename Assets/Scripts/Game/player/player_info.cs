using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_info : MonoBehaviour
{
    public List<Sprite> colours;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = colours.Find(x => x.name == "duck_" + PlayerPrefs.GetString("colour"));
    }
}
