using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneState : ScriptableObject
{
    public Vector3 lastPosition_AI = new Vector3(0,0,0);
    public Vector3 lastPosition_CorridoioM = new Vector3(0,0,0);
    public void ResetData() // imposta la posizione a (0, 0, 0) ogni volta che fa ripartire il gioco
    {
        lastPosition_AI = Vector3.zero; 
        lastPosition_CorridoioM = Vector3.zero;
    }
}
