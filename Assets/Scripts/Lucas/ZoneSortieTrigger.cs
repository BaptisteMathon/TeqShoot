using UnityEngine;

public class ZoneSortieTrigger : MonoBehaviour
{
    public ZoneCameraSwitcher cameraManager;
    public Transform playerDestination;
    public GameObject player1;
    public GameObject player2;
    [Range(1, 6)] public int targetCase = 1; // Numéro de la case à cibler

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject == player1 || other.gameObject == player2) && cameraManager != null)
        {
            Debug.Log($"🚪 Sortie vers case {targetCase} touchée par : {other.name}");

            // Déplacer la caméra vers la case ciblée
            cameraManager.GoToCase(targetCase);

            // Déplacer le joueur vers la destination prévue
            if (playerDestination != null)
            {
                other.transform.position = playerDestination.position;
                Debug.Log($"🎮 Joueur déplacé vers la Case {targetCase} : {playerDestination.position}");
            }
            else
            {
                Debug.LogWarning("⚠️ Aucune destination joueur définie !");
            }
        }
    }
}
