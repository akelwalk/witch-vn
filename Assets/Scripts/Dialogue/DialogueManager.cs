using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story currentStory;
    public bool isDialoguePlaying {get; private set;}
    public float typingSpeed = 0.2f;
    private bool clicked = false;
    private bool inTypeSentence = false;
    public static DialogueManager instance {get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DialogueManager in scene");
        }
        instance = this;
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    // private void Start()
    // {
        
    // }

    private void Update()
    {
        if (!isDialoguePlaying)
        {
            return;
        }

        //So now dialogue is playing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inTypeSentence)
            {
                clicked = true;
            }
            else
            {
                clicked = false;
                ContinueStory();
            }
        }
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            string line = currentStory.Continue().Trim();
            StartCoroutine(TypeSentence(line));
        }
        else
        {
            ExitDialogueMode();
        }
    }

    IEnumerator TypeSentence(string line)
    {
        clicked = false;
        inTypeSentence = true;
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            if (clicked)
            {
                dialogueText.text = line;
                inTypeSentence = false;
                break;
            }
            dialogueText.text += letter;
            AudioManager.instance.playDialogueBeep();

            if (letter == ' ' || letter == '\n')
            {
                continue;
            }
            else if (letter == '.' || letter == '?' || letter == '?' || letter == '!' || letter == '—')
            {
                yield return new WaitForSeconds(typingSpeed * 2.4f);
            }
            else if (letter == ',')
            {
                yield return new WaitForSeconds(typingSpeed * 1.5f);
            }
            else
            {
                yield return new WaitForSeconds(typingSpeed);
            }


        }
        inTypeSentence = false;

    }

}
