using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Pairing
{
    public string key;
    public AudioClip value;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource music;
    [SerializeField] public AudioSource sfx;
    // [SerializeField] private AudioClip dialogueBeep;
    // [SerializeField] public Dictionary<string, AudioClip> sfxList = new Dictionary<string, AudioClip>();
    [SerializeField] private List<Pairing> sfxList;
    public Dictionary<string, AudioClip> sfxDictionary = new Dictionary<string, AudioClip>();
    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of AudioManager in scene");
        }
        instance = this;

        foreach (Pairing pairing in sfxList)
        {
            sfxDictionary.Add(pairing.key, pairing.value);
        }
    }

    // public void playDialogueBeep()
    // {
    //     sfx.PlayOneShot(dialogueBeep);
    // }
}
