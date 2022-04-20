using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Despawn(timer));
    }
    IEnumerator Despawn(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
