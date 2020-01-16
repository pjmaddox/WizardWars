using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private PlayerManager player;

    void Setup()
    {
        this.currentHealth = this.maxHealth;
        player = this.GetComponent<PlayerManager>();
        player.onPlayerDeath += DestroyPlayer;

    }

    private void Awake()
    {
        Setup();
    }

    public override void DestroyOnDeath()
    {
        if(this.currentHealth <= 0)
        {
            player.HandlePlayerDeath();
        }
    }

    public void HandleAbilityHit(AbilityBase ability)
    {
        this.ChangeHealth(ability.damage);
    }

    public void DestroyPlayer()
    {
        Debug.Log("Player has died!");
        Destroy(this.gameObject);
    }
}
