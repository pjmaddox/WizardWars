using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ToDo: Use this class to handle all incoming 
public class PlayerAbilityEffectReceiver : AbilityEffectReceiver
{
    private PlayerManager manager;
    private PlayerHealth health;

    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody>();
        manager = this.GetComponent<PlayerManager>();
        health = this.GetComponent<PlayerHealth>();
    }

    public override void ReceiveEffect(AbilityEffect effect)
    {
        switch(effect.TypeOfEffect)
        {
            case AbilityEffect.EffectType.Damage:
                health.TakeDamage(((DamageEffect)effect).Damage);
                break;
            //case AbilityEffect.EffectType.RelativeForce:
            //    var forceEffect = effect as RelativeForceEffect;

            //    rb.AddForce(forceEffect.);
            //    break;
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
