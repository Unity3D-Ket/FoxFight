using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAttack : MonoBehaviour
{
    public float timeattack = .5f;
    public int amount = 25;

    GameObject PTarget;
    PlayerHealth PlayerHealth;
    bool playerRange;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        PTarget = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = PTarget.GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D frog)
    {
        if (frog.gameObject == PTarget)
        {
            playerRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D frog)
    {
        if (frog.gameObject == PTarget)
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
        //    if (PTarget.tag == "Player"){
        //     Destroy(gameObject, 2f);
        //}
        //}
    }

    void attack()
    {
        timer = 0f;

        if (PlayerHealth.currentHealth > 0)
        {
            PlayerHealth.TakenDmg(amount);
        }
    }

}
