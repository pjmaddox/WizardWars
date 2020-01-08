using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{
    //ToDo: Create or borrow serializable dictionary values so theses can be modified in the editor
    public Dictionary<string, AbilityBase> activationKeyToProjectileDictionary = new Dictionary<string, AbilityBase>();

    //ToDo: these two would be the alternatives, or creating our own solution, which would be a serializable class of key / value pairs
    public List<string> abilityKeys = new List<string>();
    public List<AbilityBase> abilities = new List<AbilityBase>();

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
