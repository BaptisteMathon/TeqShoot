using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject menuPanel;
    public GameObject grid;
    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ReturnToMenu()
    {
        // Désactive le GameOver
        gameOverPanel.SetActive(false);

        // Affiche le menu principal
        if (menuPanel != null) menuPanel.SetActive(true);
        if (grid != null) grid.SetActive(false);

        // Désactive les joueurs (facultatif)
        if (player1 != null) player1.SetActive(false);
        if (player2 != null) player2.SetActive(false);
    }
}
