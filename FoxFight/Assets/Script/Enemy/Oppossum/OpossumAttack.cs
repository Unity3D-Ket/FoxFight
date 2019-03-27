using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumAttack : MonoBehaviour
{
    public float timeattack =.5f;
    public int attackDmg = 10;

    GameObject Target;
    PlayerHealth PlayerHealth;
    bool playerRange;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Target)
        {
            playerRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject == Target)
        {
            playerRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackTime();
    }


    void attackTime()
    {
        timer += Time.deltaTime;

        if (timer >= timeattack && playerRange)
        {
            attack();
        }

        //if (PlayerHealth.currentHealth <= 0)
        //{
        //    if (Target.tag == "Enemy"){
        //     Destroy(gameObject);
        //}
        //}
    }

    void attack()
    {
        timer = 0f;

        if (PlayerHealth.currentHealth > 0)
        {
            PlayerHealth.TakenDmg(attackDmg);
        }
    }

}//opoAttack
