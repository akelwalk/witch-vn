using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{

    private DialogueTrigger trigger;

    private void Awake()
    {
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }
    void OnMouseUp()
    {
        if (!DialogueManager.instance.gameOver)
        {
            trigger.startDialogue();
        }
        
    }
}
