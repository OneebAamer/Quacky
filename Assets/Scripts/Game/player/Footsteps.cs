using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] steps;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        step();
    }
    IEnumerator step()
    {
        AudioClip clip = getRandomClip();
        yield return new WaitForSeconds(2);
        audioSource.PlayOneShot(clip);
        step();
    }
    private AudioClip getRandomClip()
    {
        return steps[Random.Range(0, steps.Length)];
    }
}
