using UnityEngine;

public class PowerUnlockManager : MonoBehaviour
{
    public GameObject powerUnlockPanel;
    public GameObject menuPanel;
    public GameObject grid;
    public GameObject player1;
    public GameObject player2;

    public void ReturnToMenu()
    {
        if (powerUnlockPanel != null) powerUnlockPanel.SetActive(false);
        if (menuPanel != null) menuPanel.SetActive(true);
        if (grid != null) grid.SetActive(false);
        if (player1 != null) player1.SetActive(false);
        if (player2 != null) player2.SetActive(false);

        Debug.Log("🧭 Retour au menu depuis le coffre.");
    }
}
