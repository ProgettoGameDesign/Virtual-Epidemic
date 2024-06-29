using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class Pagine : MonoBehaviour, InteractInterface
{
    [SerializeField] private SceneState diario;
    [SerializeField] private string _prompt;
    [SerializeField] private InventorySO inventoryData;
    [SerializeField] private Item item1;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        if(_prompt == "Pagina1")
        {
            diario.Pagina1 = true;
            Invoke("AddToInventory", 1.8f);
            
            
        }
        
        if(_prompt == "Pagina2")
        {
            diario.Pagina2 = true;
            Invoke("AddToInventory", 0.7f);
            
        }
        
        if(_prompt == "Pagina3")
        {
            diario.Pagina3 = true;
            Invoke("AddToInventory", 0.9f);
            
        }
        if(_prompt == "Pagina4")
        {
            diario.Pagina4 = true;
            Invoke("AddToInventory", 1.8f);
            
        }
        if(_prompt == "Schema")
        {
            diario.Pagina5 = true;
            Invoke("AddToInventory", 1.8f);
            
        }
        return true;
    }
    void AddToInventory()
    {
        if (item1 != null )
            {
                //Debug.Log("prova");
                inventoryData.AddItem(item1.InventoryItem, item1.Quantity);
            }


    }
}
