using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 200, currentHealth;
    int amount;
    public Slider healthSlider;

    Animator anim;
    Player Player; //reference to Player Script
    bool dead;
    bool damage;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        Player = GetComponent<Player>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakenDmg(int amount)
    {
        damage = true;

        currentHealth -= amount;
        healthSlider.value = currentHealth;

        //anim.SetBool("Hurting", true);

        //if (!damage) TODO: Fix Hurting Animation off
        //{
        //    anim.SetBool("Hurting", false);
        //}

        if (currentHealth <= 0 ) {
            Death();
        }

    }

    public void Death()
    {
        dead = true;
    
        Destroy(gameObject, .5f); //TODO: add in the hurt animation
        Player.enabled = false; //stops player from moving when dead
        SceneManager.LoadScene("MainMenu"); //TODO: Create a wait a few seconds before returning to mainmenu
    }

} //playerHealth
