using UnityEngine;

public class SyncCameras : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;

    void LateUpdate()
    {
        if (mainCamera != null && secondaryCamera != null)
        {
            // Sincronizza posizione e rotazione della telecamera secondaria con la principale
            secondaryCamera.transform.position = mainCamera.transform.position;
            secondaryCamera.transform.rotation = mainCamera.transform.rotation;
            secondaryCamera.transform.localScale = mainCamera.transform.localScale;
        }
    }
}
