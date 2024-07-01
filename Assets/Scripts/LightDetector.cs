using UnityEngine;
using VLB;

public class LightDetector : MonoBehaviour
{
    public VolumetricLightBeam torchLight; // Assegna qui il componente Light della torcia
    public GameObject wallText; // Assegna qui il GameObject che contiene la scritta
    public Color colorToMatch;

    void Update()
    {
        // Verifica se il muro è inquadrato dalla luce della torcia
        if (IsWallIlluminated())
        {
            wallText.GetComponent<Renderer>().enabled = true; // Mostra la scritta
        }
        else
        {
            wallText.GetComponent<Renderer>().enabled = false; // Nasconde la scritta
        }
    }

    private bool IsWallIlluminated()
    {
        // Esegui un Raycast dalla posizione della torcia nella direzione della sua luce
        Ray ray = new Ray(torchLight.transform.position, torchLight.transform.forward);
        RaycastHit hit;
        
        // Disegna il raggio per il debug
        Debug.DrawRay(ray.origin, ray.direction * torchLight.raycastDistance, Color.red);

        if (Physics.Raycast(ray, out hit, torchLight.raycastDistance))
        {

            // Verifica se il Raycast colpisce il muro
            if (hit.collider.gameObject == gameObject && torchLight.color == colorToMatch)
            {
                Debug.Log("Raggio ha colpito il muro");
                return true;
            }
        }

        return false;
    }
}
