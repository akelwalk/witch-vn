using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private GameObject characterObject; 
    [SerializeField] private GameObject speakerPanel; 
    private Animator characterAnimator;
    private Story currentStory;
    public bool isDialoguePlaying {get; private set;}
    public float typingSpeed = 0.1f;
    public GameObject continueIcon;
    private bool clicked = false;
    private bool inTypeSentence = false;
    private bool inChoice = false;

    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    public static DialogueManager instance { get; private set; }

    [Header("Tags")]
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
     private const string ITALICS_TAG = "italics";

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DialogueManager in scene");
        }
        instance = this;

        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        continueIcon.SetActive(false);

        //getting the choices text boxes
        choicesText = new TextMeshProUGUI[choices.Length];
        int i = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[i] = choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
            choice.SetActive(false);
        }
        characterAnimator = characterObject.GetComponent<Animator>();

    }

    private void Update()
    {
        if (!isDialoguePlaying)
        {
            return;
        }

        //So now dialogue is playing
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
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
        continueIcon.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            continueIcon.SetActive(false);
            string line = currentStory.Continue().Trim();
            StartCoroutine(TypeSentence(line));

            //function call to DisplayChoices() is in the TypeSentence coroutine

            HandleTags(currentStory.currentTags);
            
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            //parse tage
            string[] splitTag = tag.Split(':');

            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag couldn't be parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    speakerPanel.SetActive(tagValue != "");
                    displayNameText.text = tagValue;
                    
                    break;
                case PORTRAIT_TAG:
                    characterObject.SetActive(tagValue != "");
                    characterAnimator.Play(tagValue);
                    break;
                case ITALICS_TAG:
                    if (tagValue == "true")
                    {
                        dialogueText.fontStyle = FontStyles.Italic;
                    }
                    else
                    {
                        dialogueText.fontStyle = FontStyles.Normal;
                    }
                    break;
                default:
                    Debug.LogWarning("Tag key is currently not handled: " + tagKey);
                    break;

            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        continueIcon.SetActive(true);
        if (currentChoices.Count > 0)
        {
            continueIcon.SetActive(false);
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

        StartCoroutine(SelectFirstChoice(currentChoices.Count));
    }

    private IEnumerator SelectFirstChoice(int choiceLength)
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        if (choiceLength > 0)
        {
            EventSystem.current.SetSelectedGameObject(choices[choiceLength-1].gameObject);
        }
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
            else if (letter == '.' || letter == '?' || letter == ';' || letter == '!' || letter == '—')
            {
                yield return new WaitForSeconds(typingSpeed * 2.4f);
            }
            else if (letter == ',')
            {
                yield return new WaitForSeconds(typingSpeed * 1.7f);
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
