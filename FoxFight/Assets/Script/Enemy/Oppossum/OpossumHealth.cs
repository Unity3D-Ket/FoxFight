using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumHealth : MonoBehaviour
{
    public int enemyHealth = 100, currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        death();
    }

    public void death()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void damageTaken(int attackdmg)
    {
        currentHealth -= attackdmg;
    }

}
