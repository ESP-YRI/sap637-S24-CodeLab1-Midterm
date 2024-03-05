using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    public Sprite normalSprite;
    public Sprite evilSprite;
    public float forceAmt = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRb.AddForce(Vector2.up * forceAmt);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            playerRb.AddForce(Vector2.left * forceAmt);
            playerSprite.flipX = false;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            playerRb.AddForce(Vector2.down * forceAmt);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            playerRb.AddForce(Vector2.right * forceAmt);
            playerSprite.flipX = true;
        }

        playerRb.velocity *= .999f;
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            if (Input.GetKey(KeyCode.K))
            { 
                other.gameObject.tag = "Killed";
                GameManager.Instance.interactionsLeft--;
                playerSprite.sprite = evilSprite;
                Invoke("becomeNormal", 1.5f);
            }
            else if (Input.GetKey(KeyCode.L))
            {
                other.gameObject.tag = "Spared";
                GameManager.Instance.interactionsLeft--;
            }
        }
    }

    private void becomeNormal()
    {
        playerSprite.sprite = normalSprite;
    }
}
