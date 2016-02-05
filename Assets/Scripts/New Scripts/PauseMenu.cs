using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public string levelSelect;
    public string mainMenu;
    private bool isPaused;

    private AudioSource audioSource;
    public GameObject pauseCanvas;

    // Use this for initialization
    void Start()
    {
        pauseCanvas.SetActive(false);
        isPaused = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
            SetPaused(isPaused);
        }
    }

    public void SetPaused(bool b)
    {      
        if (b)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
           // audioSource.PlayOneShot(audioSource.clip);
            audioSource.Play();
        }
        else
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1f;
            audioSource.Stop();
        }
    }
}
