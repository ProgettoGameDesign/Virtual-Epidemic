using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    [SerializeField] SceneState sceneState;
    [SerializeField] GameObject _lucina;
    private Light _light;
    void Start()
    {
        _light = gameObject.GetComponent<Light>();

    }

    void Update()
    {
        if (sceneState._lightup == true)
        {
            _light.enabled = true;
            _lucina.SetActive(false);
            SetAmbientColor(new Color(0.6f, 0.6f, 0.6f));
        }


    }

    void SetAmbientColor(Color ambientColor)
    {
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = ambientColor;
    }
}


