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

        if(auraInfo.vfx != null)
        {
            var effect = Instantiate(auraInfo.vfx, myTransform);
            Destroy(effect, auraInfo.auraDuration);
        }

        Debug.Log($"Generated aura for ability: {newAura.aura.abilityName}");
    }

    public void Update()
    {
        var currentTime = Time.time;
        //Remove auras that should have ended
        var numberOfRemovedAuras = activeAuras.RemoveAll(x => x.endTime <= currentTime);
        if(numberOfRemovedAuras != 0)
        {
            Debug.Log($"Removed {numberOfRemovedAuras} auras this update");
        }

        //Loop through each active aura
        foreach(AuraTrackingInfo ax in activeAuras)
        {
            if (ax.aura.doesPulse) //If it is a pulse, check if the corresponding timer is ready, then apply
            {
                if (currentTime >= ax.nextPulseActivationTime)
                {
                    CheckForEffectedTargetsAndApplyEffects(ax);

                }
            }
            else //Otherwise, apply
            {
                CheckForEffectedTargetsAndApplyEffects(ax);
            }
        }
    }

    private void CheckForEffectedTargetsAndApplyEffects(AuraTrackingInfo ax)
    {
        List<AbilityEffectReceiver> things = new List<AbilityEffectReceiver>();
        Collider[] hits = Physics.OverlapSphere(myTransform.position, ax.aura.auraRadius);

        if(hits.Length > 0)
        {
            Debug.Log(hits.Length);
            foreach(var x in hits)
            {
                //When aura finds itself in overlap sphere, check whether or not it should apply to the caster
                if(x.gameObject == this.gameObject && !ax.aura.doesEffectSelf)
                {
                    continue;
                }

                var abilityReceiver = x.gameObject.GetComponent<AbilityEffectReceiver>();
                if (abilityReceiver != null)
                {
                    ApplyAllEffectsToTarget(abilityReceiver, ax.aura.auraEffects);

                    if(ax.aura.doesPulse) //Reset pulse activation time
                    {
                        ax.nextPulseActivationTime = Time.time + ax.aura.pulseDelay;
                    }
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
