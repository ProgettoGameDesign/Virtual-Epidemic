using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
   [field: Header("Door SFX")]
   [field: SerializeField] public EventReference openDoor {get; private set; }
   
   [field: Header("Music")]
   [field: SerializeField] public EventReference music { get; private set; }

   public static FMODEvents instance { get; private set; } 

   private void Awake()
   {
    if (instance != null)
    {
        Debug.LogError("Found more than one FMOD Event in the scene.");

    }
    instance = this;
   }
        
    
}
