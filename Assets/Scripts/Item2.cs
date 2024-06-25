using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Inventory.Model;

public class Item2 : MonoBehaviour, InteractInterface
{
    [SerializeField] private SceneState playerData;
    [SerializeField] private string _prompt;
    [SerializeField] private InventorySO inventoryData;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        Item item = gameObject.GetComponent<Item>();
        if (item != null )
        {
            inventoryData.AddItem(item.InventoryItem, item.Quantity);
        }
        return true;
    }
}
