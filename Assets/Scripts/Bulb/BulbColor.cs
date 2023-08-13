using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbColor
{
    public int Name { get; }
    public Dictionary<BulbColor, BulbColor> Combinations { get; }

    public BulbColor(int name)
    {
        Name = name;
        Combinations = new Dictionary<BulbColor, BulbColor>();
    }

    public void AddCombination(BulbColor other, BulbColor result)
    {
        Combinations.Add(other, result);
    }

    public int RunCombination(BulbColor object1)
    {
        if (Combinations.ContainsKey(object1))
        {
            return Combinations[object1].Name;
        }
        else
        {
            return -1;
        }
    }
}
