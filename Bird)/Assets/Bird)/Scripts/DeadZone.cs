using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    GameObject[] warnings;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "SawRight(Clone)" && this.gameObject.name == "DeadZoneRight")
        {
            Instantiate(warnings[0], collision.gameObject.transform.position - new Vector3(7f, -0.5f, 0), Quaternion.Euler(0, 0, 90));
        }
        if (collision.gameObject.name == "SawLeft(Clone)" && this.gameObject.name == "DeadZoneLeft")
        {
            Instantiate(warnings[1], collision.gameObject.transform.position + new Vector3(7f, 0.5f, 0), Quaternion.Euler(0, 0, 90));
        }
    }
}
