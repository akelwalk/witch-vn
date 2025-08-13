using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { get; private set; }
    public bool paused = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject buttons;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of PauseManager in scene");
        }
        Instance = this;
        pauseMenu.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseGame();
            }
            else
            {
                CoroutineResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        EventSystem.current.SetSelectedGameObject(null);
        //freeze game and enable pause menu
        paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        controls.SetActive(false);
        buttons.SetActive(true);
    }

    //need to resume time no matter what button you press tho
    public void CoroutineResumeGame()
    {
        pauseMenu.SetActive(false);
        //unfreeze game and hide pause menu
        StartCoroutine(ResumeGame());
    }

    public void GoHome()
    {
        StartCoroutine(ResumeGame());
        SceneManager.LoadScene(0);
    }

    public void RestartScene()
    {
        StartCoroutine(ResumeGame());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator ResumeGame()
    {

        Time.timeScale = 1;
        yield return new WaitForSeconds(0.1f); //weird stuff happens without this
        paused = false;
        if (DialogueManager.instance != null)
        {
            DialogueManager.instance.DisplayChoices();
        }
        
    }

    public void showControls()
    {
        controls.SetActive(true);
        buttons.SetActive(false);
    }

    public void showButtons()
    {
        controls.SetActive(false);
        buttons.SetActive(true);
    }
}
