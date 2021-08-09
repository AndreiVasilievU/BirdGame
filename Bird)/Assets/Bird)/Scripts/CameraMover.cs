using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    GameObject player;

    private Vector3 offSet;
    private void Awake()
    {
        player = GameObject.Find("Player");
        offSet = transform.position - player.transform.position;
    }

    private void LateUpdate()
    { 
        transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z) + offSet;
    }
}
