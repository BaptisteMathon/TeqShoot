using UnityEngine;

public class CoffreTrigger : MonoBehaviour
{
    public GameObject powerUnlockPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            powerUnlockPanel.SetActive(true);
            Debug.Log("📦 Coffre ouvert ! Pouvoir débloqué.");
        }
    }
}
