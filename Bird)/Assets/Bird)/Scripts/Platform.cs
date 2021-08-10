using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    const string DeadZone = "DeadZone";
    const string Best = "Best";

    Collider2D platformColl;
    GameObject player;

    [SerializeField]
    Sounds sounds;

    [SerializeField]
    GameObject Count;

    [SerializeField]
    TrapsConfig trapsConfig;
    [SerializeField]
    CoinsConfig coinsConfig;
    [SerializeField]
    Transform spawnTr;
    [SerializeField]
    GameObject BestScore;
    [SerializeField]
    Text textCount;

    GameObject trap;
    GameObject coin;

    private void Awake()
    {
        platformColl = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");

        if (trap == null)
        {
            CreateTrap();
        }

        if(coin == null)
        {
            CreateCoin();
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && player.transform.position.y > transform.position.y)
        {
            platformColl.isTrigger = false;

            GameInfo.Score++;
            sounds.PlaySound(sounds.soundClip[1]);

            Count.SetActive(true);
            textCount.text = GameInfo.Score.ToString();

            if(BestScore.activeSelf == true)
            {
                BestScore.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == DeadZone)
        {
            platformColl.isTrigger = true;
            Count.SetActive(false);

            if (GameInfo.Score == PlayerPrefs.GetInt(Best) - 4 && GameInfo.Score > 6)
            {
                BestScore.SetActive(true);
            }

            Destroy(trap);
            Destroy(coin);
            
            transform.position += new Vector3(0, 15f, 0);

            CreateTrap();
            CreateCoin();
        }
    }

    void CreateTrap()
    {
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            trap = Instantiate(trapsConfig.TrapsConfigure[Random.Range(0, trapsConfig.TrapsConfigure.Count)].Trap,
                new Vector3(Random.Range(-2, -1), spawnTr.transform.position.y, spawnTr.transform.position.z), Quaternion.identity, spawnTr);
        }
        else
        {
            trap = Instantiate(trapsConfig.TrapsConfigure[Random.Range(0, trapsConfig.TrapsConfigure.Count)].Trap,
                new Vector3(Random.Range(2, 3), spawnTr.transform.position.y, spawnTr.transform.position.z), Quaternion.identity, spawnTr);
        }
    }

    void CreateCoin()
    {
        if(GameInfo.Score < 8)
        {
            coin = Instantiate(coinsConfig.CoinsConfigure[0].Coin, new Vector3(Random.Range(-2, 2),
                spawnTr.transform.position.y + Random.Range(1, 2), spawnTr.transform.position.z), Quaternion.identity,spawnTr);
        }
        else if(GameInfo.Score > 8)
        {
            coin = Instantiate(coinsConfig.CoinsConfigure[1].Coin, new Vector3(Random.Range(-2, 2),
                spawnTr.transform.position.y + Random.Range(1, 2), spawnTr.transform.position.z), Quaternion.identity, spawnTr);
        }
    }

}