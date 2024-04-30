using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // Reference to the pause panel GameObject
    private bool isPaused;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();

            isPaused = !isPaused; // Toggle the isPaused flag
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true); // Activate the pause panel
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false); // Deactivate the pause panel
    }
}
