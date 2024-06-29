using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public class Key : MonoBehaviour, InteractInterface
{
    [SerializeField] private SceneState playerData;
    [SerializeField] private string _prompt;
    [SerializeField] private InventorySO inventoryData;
    [SerializeField] private Item item1;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        playerData._hasKey = true;
        gameObject.SetActive(false); 
        if (item1 != null )
        {
            //Debug.Log("prova");
            inventoryData.AddItem(item1.InventoryItem, item1.Quantity);
        }
        
        return true;
        
    }
}
