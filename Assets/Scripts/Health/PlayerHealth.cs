using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health {
    
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy" && invincibilityTimer > invincibilityTime)
        {
            Debug.Log("Aua");
            invincibilityTimer = 0;
            HealthChange(-1);
        }
            
    }

    private void Update()
    {
        invincibilityTimer += Time.deltaTime;
    }

    public override void HealthChange(int change)
    {
        base.HealthChange(-1);
        healthSlider.value = currentHealth / maxHealth;
    }
}
