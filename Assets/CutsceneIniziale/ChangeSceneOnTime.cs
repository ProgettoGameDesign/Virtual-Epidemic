using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTime : MonoBehaviour
{
    public float changeTime;
    public string sceneName;


    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            CaricaAmbienteIniziale();
        }
    }
    public void CaricaAmbienteIniziale()
    {
        SceneManager.LoadScene(sceneName);
    }
}
