using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HealthChange(-1);
            Debug.Log("Das tat weh! Minus Eins. " + currentHealth);
        }
        if (currentHealth == 0)
            Destroy(this.gameObject);
    }
}
