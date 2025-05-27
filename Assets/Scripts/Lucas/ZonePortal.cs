//ZonePortal.cs
using UnityEngine;

public class ZonePortal : MonoBehaviour
{
    public Transform destination;         // où téléporter le joueur
    public GameObject wallBehind;         // optionnel : mur pour bloquer le retour

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = destination.position;

            if (wallBehind != null)
                wallBehind.SetActive(true); // empêche de repasser la porte
        }
    }
}
