using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    public float movespeed;
    private Rigidbody2D posbody;
    private Transform TPlayer;

    float faceLeft;

    void Awake()
    {
        posbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

        TPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        faceLeft = posbody.transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        Flip(posbody);
        transform.position = Vector2.MoveTowards(transform.position, TPlayer.position, movespeed * Time.deltaTime);
    }

    void Flip(Rigidbody2D posbody)
    {
        if (posbody.transform.position.x >= TPlayer.transform.position.x)
        {
            transform.localScale = new Vector2(faceLeft, transform.localScale.y);
        }else {
            transform.localScale = new Vector2(-faceLeft, transform.localScale.y);
        }

    }//Flip

    void OnTriggerEnter2D(Collider2D posbody)
    {
        if (posbody.tag == "DeSpawn")
        {
            gameObject.SetActive(false);
        }
    }

}//Opossum