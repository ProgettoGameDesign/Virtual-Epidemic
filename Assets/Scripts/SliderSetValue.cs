using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetValue : MonoBehaviour
{
    [SerializeField] GameObject sliderMusica;
    [SerializeField] GameObject sliderSFX;
    void Start()
    {
        sliderMusica.GetComponent<Slider>().value = 0.1f;
        sliderSFX.GetComponent<Slider>().value = 0.1f;
    }

    
}
