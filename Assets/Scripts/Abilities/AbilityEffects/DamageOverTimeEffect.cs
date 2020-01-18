using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability Effect/Damage Over Time Effect")]
public class DamageOverTimeEffect : AbilityEffect
{
    [HideInInspector]
    new readonly public EffectType TypeOfEffect = EffectType.DamageOverTime;

    public float DamagePerSecond = 1f;
}