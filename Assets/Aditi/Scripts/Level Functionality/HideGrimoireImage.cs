using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGrimoireImage : MonoBehaviour
{
    void FixedUpdate()
    {
        bool grimoireAcquired = ((Ink.Runtime.BoolValue)DialogueManager.instance.GetVariableState("answered_riddle")).value;
        if (grimoireAcquired) {
            gameObject.SetActive(false);
        }   
    }
}
