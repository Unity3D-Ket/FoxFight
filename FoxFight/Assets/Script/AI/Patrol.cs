using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject Player;
    private Transform TPlayer;
    private bool movingLeft = true;
    private Rigidbody2D oposBody;
    private float faceposition;

    public float speed;
    public float raylength;
    public Transform detection;


    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        oposBody = GetComponent<Rigidbody2D>();
        TPlayer = Player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        patrolling();
    }

    public void patrolling()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(detection.position, Vector2.down, raylength);
        if (ground.collider == false)
        {
            if (movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (oposBody.transform.position.x >= TPlayer.position.x)
        {
            transform.localScale = new Vector2(faceposition, transform.localScale.y);
            transform.position = Vector2.MoveTowards(transform.position, TPlayer.position, speed * Time.deltaTime);
        }
        else
        {
            transform.localScale = new Vector2(-faceposition, transform.localScale.y);
            transform.position = Vector2.MoveTowards(transform.position, TPlayer.position, -speed * Time.deltaTime);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        patrolling();
    }

}//patrol