using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject grid;

    public GameObject player1; 
    public GameObject player2;

    public Transform spawnPoint;

    public GameObject selectedFrame1;
    public GameObject selectedFrame2;

    private GameObject selectedPlayer;

    public HealthBar HealthBar;
    public Animator Animator;

    void Start()
    {
        ResetToMenu();
    }

    public void SelectPlayer1()
    {
        selectedPlayer = player1;
        HighlightSelection(1);
    }

    public void SelectPlayer2()
    {
        selectedPlayer = player2;
        HighlightSelection(2);
    }

    public void StartGame()
    {
        if (selectedPlayer == null)
        {
            Debug.LogWarning("Aucun personnage sélectionné !");
            return;
        }

        menuPanel.SetActive(false);
        grid.SetActive(true);

        selectedPlayer.transform.position = spawnPoint.position;
        selectedPlayer.SetActive(true);

        FindFirstObjectByType<ZoneCameraSwitcher>()?.ResetCameraToCase1();
        Debug.Log("📷 Caméra recentrée sur la Case 1 après Start");

        HealthBar.SetMaxHealth(100);
        Animator.SetBool("Alive", true);
        GetComponent<PlayerMouvement>().enabled = true;  
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetToMenu()
    {
        menuPanel.SetActive(true);
        grid.SetActive(false);

        if (player1 != null) player1.SetActive(false);
        if (player2 != null) player2.SetActive(false);

        selectedPlayer = null;

        HighlightSelection(null);
        FindFirstObjectByType<ZoneCameraSwitcher>()?.ResetCameraToCase1();
        Debug.Log("🔄 Retour au menu principal terminé !");
    }

    void HighlightSelection(int? selected)
    {
        if (selectedFrame1 != null)
        {
            var img = selectedFrame1.GetComponent<Image>();
            if (img != null)
                img.color = (selected == 1) ? Color.green : Color.white;
        }

        if (selectedFrame2 != null)
        {
            var img = selectedFrame2.GetComponent<Image>();
            if (img != null)
                img.color = (selected == 2) ? Color.green : Color.white;
        }
    }
}
