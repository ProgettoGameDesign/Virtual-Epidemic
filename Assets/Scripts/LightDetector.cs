using UnityEngine;

public class LightDetector : MonoBehaviour
{
    public Light torchLight; // Assegna qui il componente Light della torcia
    public GameObject wallText; // Assegna qui il GameObject che contiene la scritta

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
        Debug.DrawRay(ray.origin, ray.direction * torchLight.range, Color.red);

        if (Physics.Raycast(ray, out hit, torchLight.range))
        {

            // Verifica se il Raycast colpisce il muro
            if (hit.collider.gameObject == gameObject && torchLight.color == Color.red)
            {
                Debug.Log("Raggio ha colpito il muro");
                return true;
            }
        }

        return false;
    }
}
