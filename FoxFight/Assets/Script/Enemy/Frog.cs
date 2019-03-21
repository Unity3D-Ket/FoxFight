using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    
    public float movespeed;
    private Rigidbody2D frogbody;
    private Animator anim;
    private Transform TPlayer;


    // Start is called before the first frame update
    void Awake()
    {
        frogbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Start()
    {
        frogAnim();
        TPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, TPlayer.position, movespeed * Time.deltaTime);
    }

    void frogAnim()
    { //TODO: Add in temp pause enemy movement to add in idle animation

        if (movespeed >= 0) //works only when its greater & equal to movespeed
        {
            anim.SetBool("Jump", true);
            //anim.SetBool("Idle", false);
             
        }
        else { 
            anim.SetBool("Jump", false);
            //anim.SetBool("Idle", true);
        }

    }//frogAnim

}//frog
