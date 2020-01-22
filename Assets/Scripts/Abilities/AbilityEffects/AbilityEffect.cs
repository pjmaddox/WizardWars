using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect : ScriptableObject
{
    public enum EffectType
    {
        DamageOverTime,
        RelativeForce,
        WorldForce,
        Damage,
        Slow
    }

    [HideInInspector]
    public EffectType TypeOfEffect;
}
