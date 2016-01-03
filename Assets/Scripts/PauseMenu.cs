using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject defaultButton;
    public string mainMenu;
    public AudioSource pauseMusic;

    private bool isPaused = false;

    // Use this for initialization
    void Start()
    {
        pauseUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(defaultButton);

        pauseMusic.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (!isPaused)
            {
                // play shitty music
                pauseMusic.PlayOneShot(pauseMusic.clip, MainGameManager.master_volume * MainGameManager.music_volume);
            }
            else
            {
                pauseMusic.Stop();
            }

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

    public void MainMenu()
    {
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