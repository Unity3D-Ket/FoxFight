using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 200, currentHealth, amount;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashcolor = new Color(1f,0f,0f,.1f);

    Animator anim;
    Player Player; //reference to Player SCript
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
        ScreenFlash();
        TakenDmg(amount);
    }

    public void ScreenFlash()
    {
        if (damage)
        {
            damageImage.color = flashcolor;
        }
        else {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damage = false;
    }

    public void TakenDmg(int amount)
    {
        damage = true;

        currentHealth -= amount;
        healthSlider.value = currentHealth;

        anim.SetTrigger("Hurt");

        //if (currentHealth <= 0 ) {
        //    Death();
        //}

    }

    //public void Death()
    //{
    //    dead = true;
    //
    //    Destroy(gameObject);
    //    Player.enabled = false; //stops player from moving when dead
    //}

} //playerHealth
