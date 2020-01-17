using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ability Effect/Relative Force Effect")]
public class RelativeForceEffect : AbilityEffect
{
    [HideInInspector]
    new readonly EffectType TypeOfEffect = EffectType.RelativeForce;

    [HideInInspector]
    public Transform forceRelativeToThisTransform;

    public enum RelativeKnockbackDirection { Towards, Away }

    public RelativeKnockbackDirection Direction = RelativeKnockbackDirection.Away;
    public float Force = 50f;
    public ForceMode ForceType;
}
