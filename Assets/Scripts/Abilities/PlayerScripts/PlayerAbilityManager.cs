using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilityManager : MonoBehaviour
{
    //ToDo: Create or borrow serializable dictionary values so theses can be modified in the editor
    public Dictionary<string, AbilityBase> activationKeyToProjectileDictionary = new Dictionary<string, AbilityBase>();

    //ToDo: these two would be the alternatives, or creating our own solution, which would be a serializable class of key / value pairs
    public List<string> abilityKeys = new List<string>();
    public List<AbilityBase> abilities = new List<AbilityBase>();
    public GameObject parentPanel;
    public GameObject abilityIcon;



    private float iconSpacing = 120f;
    void Start()
    {
        int count = 0;
        foreach(AbilityBase ab in abilities)
        {
            ab.Initialize(this.gameObject);
            GameObject iconObject = Instantiate(abilityIcon, parentPanel.transform, true) as GameObject;
            RectTransform rt = iconObject.GetComponent<RectTransform>();
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, count * iconSpacing, rt.rect.width);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 20, rt.rect.width);

            iconObject.GetComponent<Image>().sprite = ab.abilitySprite;
            iconObject.GetComponentInChildren<Text>().text = ab.abilityName;

            count++;
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
