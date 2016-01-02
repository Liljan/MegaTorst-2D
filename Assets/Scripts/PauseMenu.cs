using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject defaultButton;
    public string mainMenu;

    private bool isPaused = false;

    // Use this for initialization
    void Start()
    {
        pauseUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            MainGameManager.isPaused = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else if (!isPaused)
        {
            MainGameManager.isPaused = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void Resume() { isPaused = false; }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu() {
        try
        {
            Application.LoadLevel(mainMenu);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public void Quit() { Application.Quit(); }
}