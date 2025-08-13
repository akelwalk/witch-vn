using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Dialogue
{
    public List<LevelLines> dialogueLines;
}

[System.Serializable]
public class LevelLines
{
    public List<string> lines;
}

public class TransitionDialogue : MonoBehaviour
{
    [Header("Parameters")]
    public float typingSpeed = 0.1f;

    [Header("Transition Dialogue JSON File")]
    [SerializeField] private TextAsset transitionJSON;

    [Header("Dialogue UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    private bool clicked = false;
    private bool inTypeSentence = false;
    private Queue<string> dialogueQ = new Queue<string>();
    private Dialogue data;
    private int level = 0;

    public void Awake()
    {
        data = JsonUtility.FromJson<Dialogue>(transitionJSON.text); //deseralize json 
        dialogueText.text = "";
    }

    public void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        // level = // replace with getting actual level

        dialogueQ.Clear();
        foreach (string line in data.dialogueLines[level].lines)
        {
            dialogueQ.Enqueue(line);
        }

        DisplayNextDialogueLine();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inTypeSentence)
            {
                clicked = true;
            }
            else
            {
                clicked = false;
                if (dialogueQ.Count != 0)
                {
                    DisplayNextDialogueLine();
                }
                else
                {
                    //out of lines, transition to appropriate next scene
                    EndDialogue();
                }
            }
        }
    }
    public void DisplayNextDialogueLine()
    {
        if (dialogueQ.Count == 0)
        {
            // EndDialogue();
            return;
        }
        string currentLine = dialogueQ.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    public void EndDialogue()
    {
        string nextScene = "Level" + (level+1).ToString();
        SceneManager.LoadScene(nextScene);
    }

    private IEnumerator TypeSentence(string line)
    {
        clicked = false;
        inTypeSentence = true;
        bool isAddingRichTextTag = false;
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;
        foreach (char letter in line.ToCharArray())
        {
            if (clicked)
            {
                dialogueText.maxVisibleCharacters = line.Length;
                inTypeSentence = false;
                break;
            }
            //handles rich text tags
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else
            {
                dialogueText.maxVisibleCharacters++;
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
        }
        inTypeSentence = false;
    }
}
