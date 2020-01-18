using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Aura Ability")]
public class AuraAbility : AbilityBase
{
    private AuraAbilityHandler auraGenerator;

    public float auraDuration = 1f;
    public float auraRadius = 2f;
    public AbilityEffect[] auraEffects;

    //For Abilities that pulse. Set to false if the aura is constant while active.
    public bool doesPulse = false;
    public float pulseDelay = 0f;

    public override void Initialize(GameObject obj)
    {
        auraGenerator = obj.GetComponent<AuraAbilityHandler>();
    }

    public override void Activate()
    {
        Debug.Log($"{this.abilityName} was triggered!");     
        auraGenerator.GenerateAura(this);
    }
}
