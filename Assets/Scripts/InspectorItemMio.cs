using System.Collections;
using System.Collections.Generic;
using CGT;
using UnityEngine;

public class InspectorItemMio : MonoBehaviour
{
    private string nomeItem;
    private InspectObject inspectObject;
    [SerializeField] private ChiudiApriInventario chiudiApriInventario;
    public void AcquisisciNome(string nome)    
    {
        nomeItem = nome;
        //Debug.Log(nomeItem);
        //IspezionaElemento();

    }
    public void IspezionaElemento()
    {
        if(nomeItem == null)
        return;
        else  
        {
            chiudiApriInventario.SwitchActive();
            foreach (Transform child in gameObject.transform)
                {
                    if (child.gameObject.name == nomeItem)
                    {
                        inspectObject = child.GetComponent<InspectObject>();
                        InspectManager.instance.StartInspecting(inspectObject);
                        
                        return;
                    }

                }
            
        }
        
    }
    
}
