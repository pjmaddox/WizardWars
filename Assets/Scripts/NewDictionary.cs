using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class NewDictionary<Key, Value> : Dictionary<Key, Value>, ISerializationCallbackReceiver
{

    [SerializeField]
    private List<Key> keys = new List<Key>();

    [SerializeField]
    private List<Value> values = new List<Value>();

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<Key, Value> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        this.Clear();

        if (keys.Count != values.Count)
            Debug.Log(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

        for (int i = 0; i < keys.Count; i++)
            this.Add(keys[i], values[i]);
    }

}
