using UnityEngine;
using UnityEngine.UI;

public class ToggleColor : MonoBehaviour
{
    public Material grayscaleMaterial;
    private Image image;
    private Text text;
    private Material originalMaterial;
    private bool isBlackAndWhite = false;
    private float timer = 0f;
    private float initialDelay = 3.535f;
    private float interval = 7.28f;
    private float bwDuration = 1.34f;
    private bool firstTransitionDone = false;

    void Start()
    {
        image = GetComponent<Image>();
        text = GetComponent<Text>();

        if (image != null)
        {
            originalMaterial = image.material;
        }
        else if (text != null)
        {
            originalMaterial = text.material;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!firstTransitionDone && timer >= initialDelay)
        {
            SetBlackAndWhite(true);
            Invoke("ResetColor", bwDuration);
            firstTransitionDone = true;
            timer = 0f; // Reset timer for the next interval
        }
        else if (firstTransitionDone && timer >= interval)
        {
            SetBlackAndWhite(true);
            Invoke("ResetColor", bwDuration);
            timer = 0f; // Reset timer for the next interval
        }
    }

    void SetBlackAndWhite(bool toBlackAndWhite)
    {
        if (toBlackAndWhite)
        {
            if (image != null)
            {
                image.material = grayscaleMaterial; // Change to grayscale
            }
            else if (text != null)
            {
                text.material = grayscaleMaterial; // Change to grayscale
            }
        }
        else
        {
            if (image != null)
            {
                image.material = originalMaterial;
            }
            else if (text != null)
            {
                text.material = originalMaterial;
            }
        }

        isBlackAndWhite = toBlackAndWhite;
    }

    void ResetColor()
    {
        SetBlackAndWhite(false);
    }
}
