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
        //Loop through each active aura
        foreach(AuraTrackingInfo ax in activeAuras)
        {
            //If it is a pulse, check if the corresponding timer is ready
            if (Time.time < ax.endTime)
            {

            }
            //See if anyone is in range
            //If so, loop through each effect and apply to each target
        
        //Remove auras that should be inactive - maybe do this with a coroutine when the aura is generated?   
        }
    }
}
