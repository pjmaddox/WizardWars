using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    public float maxHealth = 100;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        ChangeHealth(-amount);
    }

    public void Heal(float amount)
    {
        ChangeHealth(amount);
    }

    public virtual void ChangeHealth(float delta)
    {
        Debug.Log("In ChangeHealth for Normal Health");
        this.currentHealth += delta;
        DestroyOnDeath();
    }

    public virtual void DestroyOnDeath()
    {
        if(this.currentHealth <= 0) 
        {
            Debug.Log($"{this.gameObject.name} has been destroyed!");
            Destroy(this.gameObject);
        }
    }
}
