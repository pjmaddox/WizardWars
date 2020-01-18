using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraAbilityHandler : MonoBehaviour
{
    private class AuraTrackingInfo
    {
        public AuraAbility aura;
        public float nextPulseActivationTime;
        public float endTime;
    }


    private List<AuraTrackingInfo> activeAuras = new List<AuraTrackingInfo>();
    private Transform myTransform;

    private void Awake()
    {
        myTransform = this.transform;
    }

    public void GenerateAura(AuraAbility auraInfo)
    {
        var newAura = new AuraTrackingInfo()
        {
            aura = auraInfo,
            nextPulseActivationTime = auraInfo.doesPulse ? Time.time + auraInfo.pulseDelay : Mathf.Infinity,
            endTime = Time.time + auraInfo.auraDuration
        };
        activeAuras.Add(newAura);
    }

    public void Update()
    {
        var currentTime = Time.time;
        //Remove auras that should have ended
        activeAuras.RemoveAll(x => x.endTime <= currentTime);

        //Loop through each active aura
        foreach(AuraTrackingInfo ax in activeAuras)
        {
            //If it is a pulse, check if the corresponding timer is ready
            if (ax.aura.doesPulse)
            {
                if (currentTime >= ax.nextPulseActivationTime)
                {
                    CheckForEffectedTargetsAndApplyEffects(ax);

                }
            }
            else
            {
                CheckForEffectedTargetsAndApplyEffects(ax);
            }
        }
    }

    private void CheckForEffectedTargetsAndApplyEffects(AuraTrackingInfo ax)
    {
        List<AbilityEffectReceiver> things = new List<AbilityEffectReceiver>();
        RaycastHit[] hits = Physics.SphereCastAll(myTransform.position, ax.aura.auraRadius, Vector3.zero, 0, LayerMask.NameToLayer("Battle"));
        if(hits != null)
        {
            foreach(var x in hits)
            {
                var abilityReceiver = x.transform.gameObject.GetComponent<AbilityEffectReceiver>();
                if (abilityReceiver != null)
                {
                    ApplyAllEffectsToTarget(abilityReceiver, ax.aura.auraEffects);
                }
            }
        }
    }

    private void ApplyAllEffectsToTarget(AbilityEffectReceiver abilityReceiver, AbilityEffect[] auraEffects)
    {
        foreach(var ex in auraEffects)
        {
            abilityReceiver.ReceiveEffect(ex);
        }
    }
}
