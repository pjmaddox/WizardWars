using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbilityManager : MonoBehaviour
{
    public Dictionary<string, AbilityBase> activationKeyToProjectileDictionary = new Dictionary<string, AbilityBase>();

    void Start()
    {
        foreach(KeyValuePair<string, AbilityBase> x in activationKeyToProjectileDictionary)
        {
            x.Value.Initialize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForMappedInputs();
    }

    void CheckForMappedInputs()
    {
        foreach(string x in activationKeyToProjectileDictionary.Keys)
        {
            if(Input.GetButtonDown(x))
            {
                activationKeyToProjectileDictionary[x].Activate();
            }   
        }
    }

    void AddMappedAbility(string mappedInput, AbilityBase ability)
    {
        activationKeyToProjectileDictionary.Add(mappedInput, ability);
        activationKeyToProjectileDictionary[mappedInput].Initialize();
    }
}
