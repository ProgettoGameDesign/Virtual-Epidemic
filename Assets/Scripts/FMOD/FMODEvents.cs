using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField]  public EventReference playerFootsteps {get; private set;}
    
    [field: Header("Door SFX")]
    [field: SerializeField] public EventReference openDoor {get; private set;}
   public static FMODEvents instance {get; private set;}

   private void Awake()
   {
    if (instance != null)
    {
        Debug.LogError("Found more than one FMOD event in the scene.");
    }
    instance = this;
   }

   

   
    
}
