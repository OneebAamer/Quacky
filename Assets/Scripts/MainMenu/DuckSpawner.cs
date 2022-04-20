using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public GameObject SpawnerPrefab;
    public Transform SpawnPos;
    public float interval = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(interval));
    }
    IEnumerator Spawn(float time)
    {
        bool done = false;
        if (!done)
        {
            done = true;
            yield return new WaitForSeconds(time);
            float x = Random.Range(-12.0f, 12.0f);
            float y = Mathf.Sqrt(144 - (x * x));
            Vector3 pos = new Vector3(x, y, -0.1f);
            float rotate = ((Mathf.Atan(y/x) * 180) / Mathf.PI);
            Quaternion rotation = Quaternion.Euler(0, 0,0);
            if (x <= 0)
            {
                rotation = Quaternion.Euler(0, 0, rotate);
            }
            else if(x>0)
            {
                if(y <= 0)
                {
                    rotation = Quaternion.Euler(0, 0, -180 - rotate);
                }
                else
                {
                    rotation = Quaternion.Euler(0, 0, 180 + rotate);
                }
            }
            Instantiate(SpawnerPrefab,pos,rotation);
            StartCoroutine(Spawn(interval));
        }
    }
}
