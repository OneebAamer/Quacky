using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private GameObject target;
    private CircleCollider2D inside;
    public float speed = 6f;
    Rigidbody2D rb;
    Collider2D[] hitbox;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("player");
        inside = GameObject.Find("pool").GetComponent(typeof(CircleCollider2D)) as CircleCollider2D;
        hitbox = GetComponents<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = target.transform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        movement = diff;
    }
    private void FixedUpdate()
    {
        if (inside.bounds.Contains(new Vector2(target.transform.position.x, target.transform.position.y)))
        {
            float m;
            if (target.transform.position.x == 0 | target.transform.position.y == 0)
            {
                m = 0;
            }
            else
            {
                m = target.transform.position.y / target.transform.position.x;
            }
            float r = 1.5f;
            float x = Mathf.Sqrt((r*r)/(1+(m*m)));
            if(target.transform.position.x < 0)
            {
                x = -x;
            }
            float y = m * x;
            if (target.transform.position.y < 0)
            {
                y = -y;
            }
            Vector3 pos = new Vector3(x, y, -1);
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        }
    }
    void move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "IgnoreEnemy" | collision.gameObject.tag == "seed")
        {
            for (int i = 0; i < hitbox.Length; i++)
            Physics2D.IgnoreCollision(collision.collider, hitbox[i]);
        }
    }
}
