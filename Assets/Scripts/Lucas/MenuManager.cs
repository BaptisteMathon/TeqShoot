//MenuManager.cs
using UnityEngine;

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

    void Start()
    {
        menuPanel.SetActive(true);
        grid.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        HighlightSelection(null);
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

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void HighlightSelection(int? selected)
    {
        if (selectedFrame1 != null)
        {
            var img = selectedFrame1.GetComponent<UnityEngine.UI.Image>();
            if (img != null)
                img.color = (selected == 1) ? Color.green : Color.white;
        }

        if (selectedFrame2 != null)
        {
            var img = selectedFrame2.GetComponent<UnityEngine.UI.Image>();
            if (img != null)
                img.color = (selected == 2) ? Color.green : Color.white;
        }
    }

    public void ResetGame()
    {
        FindFirstObjectByType<ZoneCameraSwitcher>()?.ResetCameraToCase1();
    }

}
