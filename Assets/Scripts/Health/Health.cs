using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour {

    public float maxHealth;
    public float invincibilityTime;
    
    protected float invincibilityTimer;
    
    [SerializeField]
    public float currentHealth { get; protected set; }

    public virtual void HealthChange(int changeAmount)
    {
        currentHealth = Mathf.Max(Mathf.Min(currentHealth + changeAmount, maxHealth), 0);
    }
}
