using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("Parameters")]
    public float typingSpeed = 0.1f;

    [Header("Globals Ink File")]
    [SerializeField] private TextAsset loadGlobalsJson;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private GameObject characterObject; 
    [SerializeField] private GameObject speakerPanel;
    
    private Animator characterAnimator;
    private SpriteRenderer characterSpriteRenderer;
    private Story currentStory;
    public bool isDialoguePlaying {get; private set;}
    
    public GameObject continueIcon;
    private bool clicked = false;
    private bool inTypeSentence = false;
    private bool inChoice = false;

    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    public static DialogueManager instance { get; private set; }

    // [Header("Tags")]
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string ITALICS_TAG = "italics";
    private const string SFX_TAG = "sfx";
    private const string TRANSITION_TAG = "transition";
    private const string GAMEOVER_TAG = "gameover";
    private const string GAME_COMPLETE_TAG = "gameComplete";
    private const string CLEAR_PORTRAIT_TAG = "clearEndPortrait";
    private const string PORTRAIT_SORTING_ORDER_TAG = "portraitSortingOrder";

    private string clearEndPortrait = ""; //could make this true if you want to ensure there's nothing that shows up rather than the default animation. however, if you make it true, at a certain point you have to make it empty again in the ink file so that the default will show up again
    private string nextScene = "";
    public bool gameOver = false;
    public bool gameFinished = false; //when you reach an ending, display thanks for playing panel

    private DialogueVariables dialogueVariables;

    [Header("Screens")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject thanksForPlayingPanel;

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
        gameOverPanel.SetActive(false);

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
        characterSpriteRenderer = characterObject.GetComponent<SpriteRenderer>();
        dialogueVariables = new DialogueVariables(loadGlobalsJson);

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

        dialogueVariables.StartListening(currentStory);

        //reset portrait and speaker
        displayNameText.text = "???";
        dialogueText.text = "???";
        characterAnimator.Play("default");
        characterSpriteRenderer.sortingOrder = -3;

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueVariables.StopListening(currentStory);
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        continueIcon.SetActive(false);
        dialogueText.text = "";

        //setting the character to default value after exiting dialogue
        characterObject.SetActive(clearEndPortrait == "");
        characterAnimator.Play("default");
        characterSpriteRenderer.sortingOrder = -3;

        //handling game over and scene transitions
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
        }
        else if (gameFinished)
        {
            thanksForPlayingPanel.SetActive(true);
        }
        else if (nextScene != "")
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            continueIcon.SetActive(false);
            string line = currentStory.Continue().Trim();
            if (line == "") //I get this weird empty line if I dont have anything to say before an end or a done
            {
                ExitDialogueMode();
            }
            else {
                StartCoroutine(TypeSentence(line));

                //function call to DisplayChoices() is in the TypeSentence coroutine

                HandleTags(currentStory.currentTags);
            }
            
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
                case SFX_TAG:
                    AudioClip clip = AudioManager.instance.sfxDictionary[tagValue]; //need to make sure tag values line up with keys in the sfxList dictionary in the unity inspector
                    AudioManager.instance.sfx.PlayOneShot(clip);
                    break;
                case GAMEOVER_TAG:
                    gameOver = true;
                    break;
                case TRANSITION_TAG:
                    nextScene = tagValue; //look at exit dialogue for scene transition
                    break;
                case CLEAR_PORTRAIT_TAG:
                    clearEndPortrait = tagValue;
                    break;
                case PORTRAIT_SORTING_ORDER_TAG:
                    characterSpriteRenderer.sortingOrder = int.Parse(tagValue);
                    break;
                case GAME_COMPLETE_TAG:
                    gameFinished = true;
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

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        dialogueVariables.variables.TryGetValue(variableName, out Ink.Runtime.Object variableValue);
        if (variableValue != null)
        {
            Debug.LogWarning("Ink variable found to be null: " + variableName);
        }
        return variableValue;
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
            AudioManager.instance.sfx.PlayOneShot(AudioManager.instance.sfxDictionary["dialogue"]);

            if (letter == ' ' || letter == '\n')
            {
                continue;
            }
            else if (letter == '.' || letter == '?' || letter == ';' || letter == '!' || letter == '—' || letter == '-')
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
