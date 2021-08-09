using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    string coin;
    Sounds sounds;
    private void Awake()
    {
        coin = gameObject.tag;
        sounds = GameObject.Find("SoundsObject").GetComponent<Sounds>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            if(coin == "Coin")
            {
                GameInfo.Money++;
                sounds.PlaySound(sounds.soundClip[2]);
                Destroy(gameObject);
            }
            else if(coin == "CoinApple")
            {
                GameInfo.Money += 2;
                sounds.PlaySound(sounds.soundClip[3]);
                Destroy(gameObject);
            }
            
        }
    }
}
