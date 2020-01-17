using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Delegate definitions
    public delegate void HitByAbilityDelegate(AbilityBase ability);
    public delegate void PlayerDeathDelegate();

    //Delegate references
    public HitByAbilityDelegate onPlayerHit;
    public PlayerDeathDelegate onPlayerDeath;

    //Handlers
    public void HandlePlayerHitByAbility(AbilityBase someAbility)
    {
        onPlayerHit?.Invoke(someAbility);
    }

    public void HandlePlayerDeath()
    {
        onPlayerDeath?.Invoke();
    }
}
