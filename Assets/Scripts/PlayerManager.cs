using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerAbilityManager abilityManager;


    public float maxHealth = 100;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.name + "'s health is: " + (int)currentHealth);
        

        if (currentHealth <= 0)
        {
            Debug.Log(this.name + " IS DEAD");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("ability"))
        {
            Debug.Log("got here");
            ProjectileAbilityStats pas = other.GetComponent<ProjectileAbilityStats>();
            
            if (pas)
            {
                currentHealth -= pas.damage;
            }
        }
    }
}
