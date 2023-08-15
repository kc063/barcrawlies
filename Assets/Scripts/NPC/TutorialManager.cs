using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static event System.Action OnTutorialOne;
    public static event System.Action OnTutorialTwo;
    public static event System.Action OnTutorialThree;

    public void TriggerOne()
    {
        OnTutorialOne.Invoke();
    }
    public void TriggerTwo()
    {
        OnTutorialTwo?.Invoke();
    }
    public void TriggerReset()
    {
        OnTutorialThree?.Invoke();
    }
}
