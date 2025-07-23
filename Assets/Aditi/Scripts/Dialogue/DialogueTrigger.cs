using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //dont need visual cue or playerin range or on trigger enter/exit functions or player tag
    // or update method or in range or interact button

    [SerializeField] bool playOnStart = false;
    [SerializeField] private TextAsset inkJson;

    public void Start()
    {
        //could add a delay or transition
        if (playOnStart)
        {
            StartCoroutine(shortPause());
        }
    }
    public void startDialogue()
    {
        if (!DialogueManager.instance.isDialoguePlaying)
        {
            DialogueManager.instance.EnterDialogueMode(inkJson);
        }

    }

    IEnumerator shortPause()
    {
        yield return new WaitForSeconds(0.001f);
        startDialogue();
    }
}
