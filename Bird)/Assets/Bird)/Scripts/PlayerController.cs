using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    SpriteRenderer playerSr;
    Animator playerAn;
    public float speed;
    public float jumpForce;
    private bool isFly = false;
    private bool isFly_2 = false;
    Sounds sounds;

    List<Collider2D> colliders2D;
    ContactFilter2D filter2D;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSr = GetComponent<SpriteRenderer>();
        playerAn = GetComponent<Animator>();

        colliders2D = new List<Collider2D>();
        filter2D = new ContactFilter2D();
        filter2D.SetNormalAngle(89, 91);
        filter2D.useNormalAngle = true;

        sounds = GameObject.Find("SoundsObject").GetComponent<Sounds>();
    }

    private void Start()
    {
        playerRb.velocity = new Vector2(speed, playerRb.velocity.y);
    }
    void Update()
    {
        if (isFly == false && Input.GetMouseButtonDown(0) && isFly_2 == false)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isFly = true;
        } 
        else if(isFly == true && Input.GetMouseButtonDown(0) && isFly_2 == false)
        {
            isFly_2 = true;
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isFly = false;
        }

        if (IsGrounded == false)
        {
            playerAn.SetBool("isFly", true);
        }
        else
        {
            isFly_2 = false;
            isFly = false;
            playerAn.SetBool("isFly", false);
        }
    }

    private void FixedUpdate()
    {
        if(playerRb.transform.position.x > 2)
        {
            playerRb.velocity = new Vector2(-speed, playerRb.velocity.y);
            playerSr.flipX = true;
        }
        else if(playerRb.transform.position.x < -2)
        {
            playerRb.velocity = new Vector2(speed, playerRb.velocity.y);
            playerSr.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            Time.timeScale = 0;
            sounds.PlaySound(sounds.soundClip[0]);
            playerAn.SetBool("isDie", true);

            if(PlayerPrefs.GetInt("Best") < GameInfo.Score)
            {
                PlayerPrefs.SetInt("Best", GameInfo.Score);
            }
            int total = PlayerPrefs.GetInt("Total");
            total += GameInfo.Money;
            PlayerPrefs.SetInt("Total", total);
        }
    }

    bool IsGrounded
    {
        get
        {
            bool _value = false;
            int _count = playerRb.GetContacts(filter2D, colliders2D);
            _value = _count > 0;
            return _value;
        }
    }
}
