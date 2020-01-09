using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Todo: USE CROSS PLATFORM INPUT MANAGER!!!!!!!!!!!!!!!!!!!!!
    public string[] acceptedInputs;
    public AbilityBase[] abilities;

    // Update is called once per frame
    void Update()
    {
        //assumes correct orderring for strings -> abilities
        for (int i = 0; i < acceptedInputs.Length; i++)
        {
            if(Input.GetButtonDown(acceptedInputs[i]))
            {
                abilities[i].Activate();
            }
        }
    }
}
