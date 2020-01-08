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
        /* foreach(KeyValuePair<string, AbilityBase> x in activationKeyToProjectileDictionary)
         {
             x.Value.Initialize();
         }
         */
        Debug.Log("123");
        foreach(AbilityBase ab in abilities)
        {
            ab.Initialize(this.gameObject);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckForMappedInputs();
        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }

    void CheckForMappedInputs()
    {
       /* foreach(string x in activationKeyToProjectileDictionary.Keys)
        {
            if(Input.GetButtonDown(x))
            {
                activationKeyToProjectileDictionary[x].Activate();
            }   
        } */

        for(int i = 0; i < abilityKeys.Count; i++)
        {
            if (Input.GetButtonDown(abilityKeys[i]))
            {
                if (i < abilities.Count)
                {
                    abilities[i].Activate();
                } else
                {
                    Debug.Log("Tried to activate an out of bounds ability");
                }
            }
        }
       
    }

    /*
    void AddMappedAbility(string mappedInput, AbilityBase ability)
    {
        activationKeyToProjectileDictionary.Add(mappedInput, ability);
        activationKeyToProjectileDictionary[mappedInput].Initialize();
    }
    */
}
