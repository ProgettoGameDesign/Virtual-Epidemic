using UnityEngine;
using UnityEngine.UI;

public class ToggleColor : MonoBehaviour
{
    private Image image;
    private Text text;
    private Color originalColor;
    public Material grayscaleMaterial;
    private Material originalMaterial;
    private bool isBlackAndWhite = false;

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

        GlobalColorManager.Instance.Subscribe(this);
    }

    void OnDestroy()
    {
        GlobalColorManager.Instance.Unsubscribe(this);
    }

    public void SetBlackAndWhite(bool toBlackAndWhite)
    {
        if (toBlackAndWhite)
        {
            if (image != null)
            {
                image.material = grayscaleMaterial;
            }
            else if (text != null)
            {
                text.material = grayscaleMaterial;
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
}
