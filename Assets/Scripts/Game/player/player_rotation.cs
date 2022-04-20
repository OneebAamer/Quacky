using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_rotation : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
        }
    }
}
