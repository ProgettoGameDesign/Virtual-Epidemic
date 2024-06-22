using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitchTarget : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // La Cinemachine Virtual Camera
    public Transform player; // Il Transform del player
    public Transform npc; // Il Transform dell'npc
    //public Animator npcAnimator; // L'Animator dell'npc

    public void SwitchToNPCTarget()
    {
        // Cambia il target della camera all'npc
        virtualCamera.Follow = npc;
        //virtualCamera.LookAt = npc;

        

        // Dopo la durata dell'animazione, torna al player
        Invoke("SwitchBackToPlayer", 7);
    }

    private void SwitchBackToPlayer()
    {
        // Cambia il target della camera al player
        virtualCamera.Follow = player;
        //virtualCamera.LookAt = player;
    }
}
