using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseUI;

    private bool isPaused = false;

	// Use this for initialization
	void Start () {
        pauseUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else if (!isPaused)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
