using UnityEngine;

public class ZoneCameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Transform cameraPointCase1;
    public Transform cameraPointCase2;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (cameraPointCase1 != null)
        {
            mainCamera.transform.position = cameraPointCase1.position;
            Debug.Log("📷 Caméra placée sur Case 1 depuis point de repère");
        }
        else
        {
            Debug.LogWarning("⚠️ cameraPointCase1 non assigné !");
        }
    }

    public void GoToCase2()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (cameraPointCase1 != null)
        {
            mainCamera.transform.position = cameraPointCase2.position;
            Debug.Log("📷 Caméra placée sur Case 1 depuis point de repère");
        }
        else
        {
            Debug.LogWarning("⚠️ cameraPointCase2 non assigné !");
        }
    }

    public void ResetCameraToCase1()
    {
        if (mainCamera != null && cameraPointCase1 != null)
        {
            mainCamera.transform.position = cameraPointCase1.position;
            Debug.Log("🔁 Caméra recentrée sur Case 1");
        }
    }
}
