using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BulbData : MonoBehaviour
{
    public int b;
    public BulbColor color;
    public BulbController bulb;
    [SerializeField] public int onResetColor;

    void Start()
    {
        b = onResetColor;
        color = bulb.getColor(b);
        Instantiate(bulb.getPlantSpew(color.Name), transform);
    }

    public void changeColor(int c)
    {
        if (c != 0){
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            BulbColor cc = bulb.SetColor(color, bulb.getColor(c));
            Debug.Log("New bulb color");
            Debug.Log(cc.Name);
            Instantiate(bulb.getPlantSpew(cc.Name), transform);
            color = cc;
            b = color.Name;
        }
    }
    
    public void Refresh()
    {
        b = onResetColor;
        color = bulb.getColor(b);
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Instantiate(bulb.getPlantSpew(color.Name), transform);
    }
}
