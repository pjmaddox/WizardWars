using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityEffectReceiver : MonoBehaviour
{
    private Health health;
    protected Rigidbody rb;

    private void Awake()
    {
        this.health = this.GetComponent<Health>();
        this.rb = this.GetComponent<Rigidbody>();
    }

    public virtual void ReceiveEffect(AbilityEffect effect)
    {
        switch(effect.TypeOfEffect)
        {
            case AbilityEffect.EffectType.Damage:
                var damageEffect = effect as DamageEffect;
                health.TakeDamage(damageEffect.Damage);
                break;
            case AbilityEffect.EffectType.DamageOverTime:
                var dotEffect = effect as DamageOverTimeEffect;
                health.TakeDamage(dotEffect.DamagePerSecond * Time.deltaTime);
                break;
            case AbilityEffect.EffectType.RelativeForce:
                //ToDo
                break;
            case AbilityEffect.EffectType.WorldForce:
                //ToDo
                break;
            default:
                return;
        }
    }
}
