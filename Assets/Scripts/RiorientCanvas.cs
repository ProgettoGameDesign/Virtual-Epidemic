using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiorientCanvas : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        // Trova la camera principale nella scena
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Orienta il canvas verso la camera
        Vector3 direction = cameraTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(-direction);
        transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
    }
}

