using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
    public float targetAspect = 16f / 9f; // Imposta l'aspect ratio target

    void Start()
    {
        Camera camera = GetComponent<Camera>();

        // Calcola l'aspect ratio attuale
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Calcola la scala dell'altezza necessaria per adattarsi all'aspect ratio target
        float scaleHeight = windowAspect / targetAspect;

        // Se l'aspect ratio attuale è inferiore all'aspect ratio target, aggiusta il viewport della camera
        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else // Se l'aspect ratio attuale è superiore all'aspect ratio target, aggiusta il viewport della camera
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}
