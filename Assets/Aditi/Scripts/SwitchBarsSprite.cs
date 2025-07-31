using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBarsSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite openBars;
    private bool doorUnlocked = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if (!doorUnlocked)
        {
            doorUnlocked = ((Ink.Runtime.BoolValue)DialogueManager.instance.GetVariableState("unlocked")).value;
            if (doorUnlocked)
            {
                spriteRenderer.sprite = openBars;
            }   
        }
        
    }
}
