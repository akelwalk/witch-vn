using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioClip dialogueBeep;

    public static AudioManager instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of AudioManager in scene");
        }
        instance = this;
    }

    public void playDialogueBeep()
    {
        sfx.PlayOneShot(dialogueBeep);
    }
}
