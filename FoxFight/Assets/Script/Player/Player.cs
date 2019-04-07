using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed = 10f, jumpmove = 15f, maxvel = 10f;
    private Rigidbody2D playerbody;
    private Animator anim;

    private bool floored;

    void Awake()
    {
        playerbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMovement();
    }

    public void playerMovement()
    {
        float moveX = 0f, moveY = 0f;

        float vel = Mathf.Abs(playerbody.velocity.x); //velocity at current X position of player

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h > 0)
        {
            if (vel < maxvel)
                moveX = movespeed;

            Vector3 rLook = transform.localScale;
            rLook.x = 5f;
            transform.localScale = rLook;

            anim.SetBool("Running", true);

        }
        else if (h < 0)
        {
            if (vel < maxvel)
                moveX = -movespeed;

            Vector3 lLook = transform.localScale;
            lLook.x = -5f;
            transform.localScale = lLook;

            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Jumping", true);

            if (floored)
            {
                
                floored = false;
                playerbody.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
                moveY = jumpmove;

            }
            else
            {
                anim.SetBool("Jumping", false);
            }

        }

        if (v < 0) //TODO: FIX 2D BOX COLLIDER TO MOVE WITH THE PLAYERBODY
        {
            anim.SetBool("Crouching", true);
            //anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Crouching", false);
            //anim.SetBool("Running", false);
        }

        playerbody.velocity = new Vector2(moveX, playerbody.velocity.y);

    } //playermovement

    void OnCollisionEnter2D(Collision2D Playerfloored)
    {
        if (Playerfloored.gameObject.tag == "Ground")
        {
            floored = true;
            //anim.SetBool("Jumping", true); failed
        }

    }


}//player
