using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability Effect/World Force Effect")]
public class WorldForceEffect : AbilityEffect
{
    [HideInInspector]
    new readonly EffectType TypeOfEffect = EffectType.RelativeForce;

    public enum RelativeKnockbackDirection { Towards, Away }

    public Vector3 Direction;
    public float Force = 50f;
    public ForceMode ForceType;
}
