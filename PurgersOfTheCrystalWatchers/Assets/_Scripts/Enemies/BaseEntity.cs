using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    public Stat MaxHealth;
    public float currentHealth;

    public string DeathParticleEffectName;
    public string HitParticleEffectName;

    protected virtual void Awake()
    {
        currentHealth = MaxHealth.GetValue();
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
