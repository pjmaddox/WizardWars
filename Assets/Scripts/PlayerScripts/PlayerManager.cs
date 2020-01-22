using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Delegate definitions
    public delegate void HitByAbilityDelegate(AbilityBase ability);
    public delegate void PlayerDeathDelegate();
    public delegate void PlayerTookDamage();

    //Delegate references
    public HitByAbilityDelegate onPlayerHit;
    public PlayerDeathDelegate onPlayerDeath;
    public PlayerTookDamage onPlayerDamaged;

    //Handlers
    public void HandlePlayerHitByAbility(AbilityBase someAbility)
    {
        onPlayerHit?.Invoke(someAbility);
    }

    public void HandlePlayerDeath()
    {
        onPlayerDeath?.Invoke();
    }
    public void HandlePlayerTookDamage()
    {
        onPlayerDamaged?.Invoke();
    }
}
