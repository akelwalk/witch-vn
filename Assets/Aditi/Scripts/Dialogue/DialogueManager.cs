using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

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
    private bool inChoice = false;

    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    public static DialogueManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DialogueManager in scene");
        }
        instance = this;

        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);

        //getting the choices text boxes
        choicesText = new TextMeshProUGUI[choices.Length];
        int i = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[i] = choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
            choice.SetActive(false);
        }

    }

    private void Update()
    {
        if (!isDialoguePlaying)
        {
            return;
        }

        //So now dialogue is playing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inTypeSentence && !inChoice)
            {
                clicked = true;
            }
            else if (!inChoice)
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

            //display choices is in the coroutine
            
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > 0)
        {
            inChoice = true;
        }

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int i = 0;

        foreach (Choice choice in currentChoices)
        {
            choices[i].SetActive(true);
            choicesText[i].text = choice.text;
            i++;
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void CoroutineMakeChoice(int choiceIndex)
    {
        StartCoroutine(MakeChoice(choiceIndex));
        MakeChoice(choiceIndex);
    }
    private IEnumerator MakeChoice(int choiceIndex)
    {
        foreach (GameObject choice in choices)
        {
            choice.SetActive(false);
        }
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory(); 
        yield return new WaitForSeconds(0.1f); //this is kinda bs'ed because without it, inChoice becomes false too fast and the spacebar down registers for a skip text
        inChoice = false;
    }

    private IEnumerator TypeSentence(string line)
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
        DisplayChoices();
    }

}
