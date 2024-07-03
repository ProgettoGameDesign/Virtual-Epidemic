using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TutorialVideoCamera : MonoBehaviour
{
    [SerializeField] GameObject canvasTutorial;
    [SerializeField] GameObject menu;
    void Update()
    {
        if (canvasTutorial.activeSelf == true)
        {
            menu.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape))
                SwitchActive();
        }
        else menu.SetActive(true);
    }
    public void SwitchActive()
    {
        canvasTutorial.SetActive(!canvasTutorial.activeSelf);

    }
}
