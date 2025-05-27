//PauseManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject menuPanel;

    public GameObject player1;
    public GameObject player2;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // stoppe le temps
    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }


    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // remet le temps à la normale
        menuPanel.SetActive(true);
        pausePanel.SetActive(false);    
        player1.SetActive(false);
        player2.SetActive(false);
    }
}
