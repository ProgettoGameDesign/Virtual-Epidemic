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
    [SerializeField] private Item item1;
    [SerializeField] TutorialVideoCamera tutorialVideoCamera;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        if (_prompt == "Telecamera")
        {
            
            tutorialVideoCamera.SwitchActive();
        }
        //Debug.Log(item1);
        gameObject.SetActive(false); 
        //playerData._torchActive = true;
        if (item1 != null )
        {
            //Debug.Log("prova");
            inventoryData.AddItem(item1.InventoryItem, item1.Quantity);
        }
        
        return true;
    }
}
