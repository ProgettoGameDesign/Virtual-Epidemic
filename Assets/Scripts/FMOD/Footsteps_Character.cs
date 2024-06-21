using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Footsteps_Character : MonoBehaviour
{

    public EventReference footstepEvent;
    public LayerMask groundLayer;
    private CharacterController characterController;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(characterController.isGrounded && characterController.velocity.magnitude > 2f)
        {
            int terreno = DetermineSurface();
            PlayFootstepsSound(terreno);

        }
    }
    
    int DetermineSurface()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.25f, groundLayer))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material mat = renderer.material;
                Debug.Log(mat);
                if (mat.name.Contains("Prato"))
                {
                    return 1;
                }
                else if (mat.name.Contains("Pavimento Cortile"))
                {
                    return 2;
                }
                
            }
        }
    
        return -1;

    }
    
    void PlayFootstepsSound(int terreno)
    {
        if (terreno < 0 || terreno > 2) return;

        FMOD.Studio.EventInstance footstepInstance = RuntimeManager.CreateInstance(footstepEvent);
        footstepInstance.setParameterByName("Terrain", terreno);
        footstepInstance.start();
        footstepInstance.release();

    }
}
        


