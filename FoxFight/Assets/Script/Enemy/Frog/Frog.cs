using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    
    public float movespeed;
    private Rigidbody2D frogbody;
    private Animator anim;
    private Transform TPlayer;

    float faceposition;


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
        faceposition = frogbody.transform.localScale.x;
    }

    void Update()
    {
        FrogFace(frogbody);
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

    void FrogFace(Rigidbody2D frogbody)
    {
        if (frogbody.transform.position.x >= TPlayer.transform.position.x)
        {
            transform.localScale = new Vector2(faceposition, transform.localScale.y);
        }else {
            transform.localScale = new Vector2(-faceposition, transform.localScale.y);
        }

    }//frogFace

    void OnTriggerEnter2D(Collider2D frogbody)
    {
        if (frogbody.tag == "DeSpawn")
        {
            gameObject.SetActive(false);
        }
    }

}//frog
