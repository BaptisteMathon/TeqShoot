using UnityEngine;

public class ZoneCameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;

    public Transform cameraPointCase1;
    public Transform cameraPointCase2;
    public Transform cameraPointCase3;
    public Transform cameraPointCase4;
    public Transform cameraPointCase5;
    public Transform cameraPointCase6;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (cameraPointCase1 != null)
        {
            mainCamera.transform.position = cameraPointCase1.position;
            Debug.Log("📷 Caméra placée sur Case 1 au démarrage");
        }
        else
        {
            Debug.LogWarning("⚠️ cameraPointCase1 non assigné !");
        }
    }

    public void GoToCase(int caseNumber)
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        Transform target = GetCameraPoint(caseNumber);

        if (target != null)
        {
            mainCamera.transform.position = target.position;
            Debug.Log($"📷 Caméra déplacée sur Case {caseNumber}");
        }
        else
        {
            Debug.LogWarning($"⚠️ cameraPointCase{caseNumber} non assigné !");
        }
    }

    private Transform GetCameraPoint(int caseNumber)
    {
        switch (caseNumber)
        {
            case 1: return cameraPointCase1;
            case 2: return cameraPointCase2;
            case 3: return cameraPointCase3;
            case 4: return cameraPointCase4;
            case 5: return cameraPointCase5;
            case 6: return cameraPointCase6;
            default: return null;
        }
    }

    public void ResetCameraToCase1()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (cameraPointCase1 != null)
        {
            mainCamera.transform.position = cameraPointCase1.position;
            Debug.Log("🔁 Caméra recentrée sur Case 1");
        }
        else
        {
            Debug.LogWarning("⚠️ cameraPointCase1 non assigné pour Reset !");
        }
    }
}
