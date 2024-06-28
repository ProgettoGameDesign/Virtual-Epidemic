using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToWhite : MonoBehaviour
{
    public Image fadePanel; // Assicurati che sia un'Image UI
    public float fadeDuration = 1.0f;
    
    private void Start()
    {
        // Inizializza il pannello come completamente trasparente
        if (fadePanel != null)
        {
            Color panelColor = fadePanel.color;
            panelColor.a = 0;
            fadePanel.color = panelColor;
        }
    }

    public IEnumerator FadeToWhiteTransition()
    {
         float elapsedTime = 0.0f;
        Color panelColor = fadePanel.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            panelColor.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadePanel.color = panelColor;
            yield return null;
        }

        // Assicurati che il pannello sia completamente opaco alla fine della transizione
        panelColor.a = 1.0f;
        fadePanel.color = panelColor;
        gameObject.SetActive(false);
    }
}
