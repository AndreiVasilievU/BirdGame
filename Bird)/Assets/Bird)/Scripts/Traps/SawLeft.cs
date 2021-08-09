using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawLeft : MonoBehaviour
{
    Rigidbody2D sawRb;

    private void Awake()
    {
        sawRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        sawRb.velocity = new Vector3(5, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DeadZoneRight")
        {
            transform.position = new Vector2(-9, transform.position.y);
        }
    }
}
