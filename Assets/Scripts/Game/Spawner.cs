using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float foxinterval = 12;
    private float seedinterval = 4;
    public GameObject fox;
    public GameObject seed;
    // Start is called before the first frame update
    void Start() 
    { 

        if (PlayerPrefs.GetString("difficulty") == "HARD")
        {
            foxinterval = foxinterval / 2;
        }
        else if (PlayerPrefs.GetString("difficulty") == "EASY")
        {
            foxinterval = foxinterval * 1.25f;
        }
        StartCoroutine(Spawn(fox, foxinterval,7f));
        StartCoroutine(Spawn(seed, seedinterval,1.5f));
    }
    // Update is called once per frame
    IEnumerator Spawn(GameObject prefab, float rate,float xpos)
    {
        while (true)
        {
            float x = Random.Range(xpos, 8f);
            float y = Random.Range(-5f, 5f);
            int[] vals = {-1,1};
            int ind = Random.Range(0, 2);
            float newx = x * vals[ind];
            Vector3 pos = new Vector3(newx, y, -1);
            Instantiate(prefab, pos, Quaternion.identity);
            Spawn(prefab, rate,xpos);
            yield return new WaitForSeconds(rate);
        }
    }
}
