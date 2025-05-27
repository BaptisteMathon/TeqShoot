using UnityEngine;

public class ZoneSortieTrigger : MonoBehaviour
{
    public ZoneCameraSwitcher cameraManager;
    public Transform playerDestination;
    public GameObject player1;
    public GameObject player2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject == player1 || other.gameObject == player2) && cameraManager != null)
        {
            Debug.Log("🚪 Zone sortie touchée par : " + other.name);
        cameraManager.GoToCase2();

            if (playerDestination != null)
            {
                other.transform.position = playerDestination.position;
                Debug.Log("🎮 Joueur déplacé vers la Case 2 : " + playerDestination.position);
            }
        }
    }

}
