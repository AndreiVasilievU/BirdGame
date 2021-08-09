using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySawSound : MonoBehaviour
{
    Sounds sounds;
    Transform playerTr;
    [SerializeField]
    AudioSource sawSoundSource;

    bool isPlayedSound = true;

    private void Start()
    {
        sounds = GameObject.Find("SoundsObject").GetComponent<Sounds>();
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        var distance = Vector3.Distance(transform.position, playerTr.position);

        if (distance <= 3.3f)
        {
            if(isPlayedSound == true)
            {
                sawSoundSource.Play();
                isPlayedSound = false;
            }
        }

        if (distance > 3.3f)
        {
            sawSoundSource.Stop();
            isPlayedSound = true;
        }
    }
}
