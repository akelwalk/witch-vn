using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] bool playOnStart = false;
    [SerializeField] private TextAsset inkJson;

    public void Start()
    {
        //could add a delay or transition
        if (playOnStart)
        {
            startDialogue();
            // StartCoroutine(shortPause());
        }
    }
    public void startDialogue()
    {
        if (!DialogueManager.instance.isDialoguePlaying)
        {
            DialogueManager.instance.EnterDialogueMode(inkJson);
        }

    }

}
