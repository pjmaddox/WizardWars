using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
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
        Debug.Log("Current health is: " + (int)currentHealth);
        currentHealth -= Time.deltaTime;

        if (currentHealth <= 0)
        {
            Debug.Log("PLAYER IS DEAD");
        }
    }
}
