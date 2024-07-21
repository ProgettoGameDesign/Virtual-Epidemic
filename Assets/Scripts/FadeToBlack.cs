using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public UnityEngine.UI.Image blackPanel;
    public float delay = 0.9f;     
    public float duration = 1.0f;
    // Start is called before the first frame update
    void Awake()
    {
        Color color = blackPanel.color;
        color.a = 0f;
        blackPanel.color = color;
        StartCoroutine(FadeInBlackPanel());
    }

    IEnumerator FadeInBlackPanel()
    {
        yield return new WaitForSeconds(delay);

        // Inizia la transizione
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            Color color = blackPanel.color;
            color.a = Mathf.Clamp01(elapsedTime / duration);
            blackPanel.color = color;
            yield return null;
        }

        
        Color finalColor = blackPanel.color;
        finalColor.a = 1f;
        blackPanel.color = finalColor;
    }
}
