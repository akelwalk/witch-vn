using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMechanic : MonoBehaviour
{
    public static SaveMechanic instance;
    public int numSlots = 3;

    private string StateJson;
    private string StoryJson;
    private int index;

    public class SaveData
    {
        public DateTime SaveTime;
        public string LevelName;
        public string StoryJson;
        public string StateJson;

        public SaveData(DateTime dt,  string levelName, string storyJson, string stateJson)
        {
            SaveTime = dt;
            LevelName = levelName;
            StoryJson = storyJson;
            StateJson = stateJson;
        }
    }

    private List<SaveData> SaveSlots = new List<SaveData>();

    private void Start()
    {
        // singleton
        if(instance == null)
        {
            instance = this;
        }
        if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);

        for (int i = 0; i < numSlots; i++) {
            SaveSlots.Add(null);
        }
    }

    public void SaveGame(int slotIndex)
    {
        DialogueManager dm = FindObjectOfType<DialogueManager>();
        StoryJson = dm.GetStory().ToJson();
        StateJson = dm.GetStory().state.ToJson();
        string levelName = SceneManager.GetActiveScene().name;

        SaveData saveData = new SaveData(DateTime.Now, levelName, StoryJson, StateJson);
        SaveSlots[slotIndex] = saveData;
    }

    public void LoadGame(int slotIndex)
    {
        index = slotIndex;
        SceneManager.sceneLoaded += OnGameLoaded;
        SceneManager.LoadScene(SaveSlots[slotIndex].LevelName);
    }

    private void OnGameLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnGameLoaded;
        StartCoroutine(WaitForDialogueManagerAndLoad());
    }

    private IEnumerator WaitForDialogueManagerAndLoad()
    {
        // Wait until the DialogueManager is initialized
        while (DialogueManager.instance == null)
        {
            yield return null;
        }

        DialogueManager dm = DialogueManager.instance;
        SaveData sd = SaveSlots[index];
        Story story = new Story(sd.StoryJson);
        story.state.LoadJson(sd.StateJson);
        dm.SetStory(story);
        dm.ContinueStory();
    }
}
