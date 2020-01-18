using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ToDo: Use this class to handle all incoming 
public class PlayerAbilityEffectReceiver : AbilityEffectReceiver
{
    private PlayerManager manager;
    private IHealth playerHealth;

    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody>();
        manager = this.GetComponent<PlayerManager>();
        playerHealth = this.GetComponent<PlayerHealth>();
    }

    public override void ReceiveEffect(AbilityEffect effect)
    {
        switch(effect.TypeOfEffect)
        {
            case AbilityEffect.EffectType.Damage:
                playerHealth.TakeDamage(((DamageEffect)effect).Damage);
                break;
            case AbilityEffect.EffectType.DamageOverTime:
                Debug.Log("Inside the damage over time ability receiver dealy-do");
                playerHealth.TakeDamage(((DamageOverTimeEffect)effect).DamagePerSecond * Time.deltaTime);
                break;
            case AbilityEffect.EffectType.WorldForce:
                var forceEffect = effect as WorldForceEffect;
                rb.AddForce(forceEffect.Direction, forceEffect.ForceType);
                break;
        }

        //ToDo...
        //Change ability to effect thing? Or is 'playerhitbyability' a different paradigm? is one better than the other?
        //manager.HandlePlayerHitByAbility(effect);
    }
}
