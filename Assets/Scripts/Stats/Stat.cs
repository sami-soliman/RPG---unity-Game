using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;

    private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);

        return finalValue;
    }

    public void AddModifier (int modifier)
    {
        Debug.Log("in adding modifier");
        if (modifier != 0)
        {
            modifiers.Add(modifier);
            Debug.Log("Adding modifier size now is " + modifiers.Count);
        }
        else
        {
            Debug.Log("did not add modifier");
        }
        
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
            Debug.Log("Removing modifier size now is " + modifiers.Count);
        }
    }
}
