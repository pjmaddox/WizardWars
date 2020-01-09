using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DictPrinter : MonoBehaviour
{
    [SerializeField]
    public StringToIntDict dictionary;
    // Start is called before the first frame update
    void Start()
    {

        dictionary.Add("a", 5);

        if (dictionary.Keys.Count > 0)
        {
            foreach (string s in dictionary.Keys)
            {
                Debug.Log(s + ": " + dictionary[s]);
            }
        }
    }
}

    
