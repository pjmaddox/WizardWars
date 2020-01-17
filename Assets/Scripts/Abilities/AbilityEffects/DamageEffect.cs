using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability Effect/Damage Effect")]
public class DamageEffect : AbilityEffect
{
    [HideInInspector]
    new readonly public EffectType TypeOfEffect = EffectType.Damage;

    public float Damage = 1f;
}
