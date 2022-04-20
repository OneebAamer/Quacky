using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveDirection = Vector3.zero;
    Rigidbody2D rb;
    Collider2D hitbox;
    [SerializeField] private AudioClip[] steps;
    private AudioSource audioSource;


    void Start()
    {
        hitbox = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchpos = Camera.main.ScreenToWorldPoint(touch.position);
            touchpos.z = 10;
            transform.position = Vector2.MoveTowards(transform.position, touchpos, speed * Time.deltaTime);
            if(!audioSource.isPlaying){
                Step();
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "IgnorePlayer")
        {
            Physics2D.IgnoreCollision(collision.collider, hitbox);
        }
    }
    private void Step()
    {
        AudioClip clip = getRandomClip();
        audioSource.volume = Random.Range(0.8f, 1);
        audioSource.pitch = Random.Range(0.8f, 1.1f);
        audioSource.PlayOneShot(clip);
    }
    private AudioClip getRandomClip()
    {
        return steps[Random.Range(0, steps.Length)];
    }
}
