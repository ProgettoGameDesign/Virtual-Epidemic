using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Inventory.UI;
using Inventory.Model;
using CGT;
using FMODUnity;
using FMOD.Studio;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private UIInventoryDescription itemDescription;

    [SerializeField]
    private MouseFollower mouseFollower;
    [SerializeField] private InspectorItemMio inspectorItemMio;
    [SerializeField] private ButtonUseScript buttonUseScript;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();
    
    private EventInstance eventInstance;
    
    
    private string fmodEventPath="event:/UI";



    private int currentlyDraggedItemIndex = -1;

    public event Action<int> OnDescriptionRequested, OnItemActionRequested, OnStartDragging;
    public event Action<int, int> OnSwapItems;

    [SerializeField]
    private ItemActionPanel actionPanel;
    

    private void Awake()
    {
        Hide();
        mouseFollower.Toggle(false);
        itemDescription.ResetDescription();
    }
    public void InitializeInventoryUI(int inventorysize)
    {

        for (int i = 0; i < inventorysize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);

            // Ripristina i parametri della trasformazione
            uiItem.transform.localPosition = new Vector3(uiItem.transform.localPosition.x, uiItem.transform.localPosition.y, 0);
            uiItem.transform.localRotation = Quaternion.identity;
            uiItem.transform.localScale = Vector3.one;

            listOfUIItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }

    internal void UpdateDescription(int itemIndex, Sprite itemImage, ItemSO itemSO, string name, string description)
    {
        //Debug.Log(itemSO.Name);
        itemDescription.SetDescription(itemImage, itemSO, itemSO.Name, description);
        DeselectAllItems();
        listOfUIItems[itemIndex].Select();
        inspectorItemMio.AcquisisciNome(name);
        buttonUseScript.AcquisisciNomeXUsa(name);
    }
    public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
    {
        if (listOfUIItems.Count > itemIndex)
        {
            listOfUIItems[itemIndex].SetData(itemImage, itemQuantity);
        }
    }
    
    private void HandleShowItemActions(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
        {
            return;
        }
        OnItemActionRequested?.Invoke(index);
    }
    private void HandleEndDrag(UIInventoryItem inventoryItemUI)
    {
        ResetDraggedItem();
    }
    private void HandleSwap(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
        {
            return;
        }
        OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
        HandleItemSelection(inventoryItemUI);
    }
    private void ResetDraggedItem()
    {
        mouseFollower.Toggle(false);
        currentlyDraggedItemIndex = -1;
    }
    private void HandleBeginDrag(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
            return;
        currentlyDraggedItemIndex = index;
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);

        //mouseFollower.Toggle(true);
        //mouseFollower.SetData(index == 0 ? image : image2, quantity);
    }
    public void CreateDraggedItem(Sprite sprite, int quantity)
    {
        mouseFollower.Toggle(true);
        mouseFollower.SetData(sprite, quantity);
    }
    private void HandleItemSelection(UIInventoryItem inventoryItemUI)
    {
        int index = listOfUIItems.IndexOf(inventoryItemUI);
        if (index == -1)
        return;
        OnDescriptionRequested?.Invoke(index);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        ResetSelection();
        PlaySoundShow();

    }
    public void ResetSelection()
    {
        itemDescription.ResetDescription();
        DeselectAllItems();
    }

    public void AddAction(string actionName, Action performAction)
    {
        Debug.Log($"AddAction called with actionName: {actionName}");
        Debug.Log($"AddAction called with performAction: {performAction}");
        actionPanel.AddButton(actionName, performAction);
        Debug.Log("AddAction completed");
    }
    public void ShowItemAction(int itemIndex)
    {
        actionPanel.Toggle(true);
        actionPanel.transform.position = listOfUIItems[itemIndex].transform.position;
    }
    private void DeselectAllItems()
    {
        foreach (UIInventoryItem item in listOfUIItems) 
        {
            item.Deselect();
        }
        actionPanel.Toggle(false);
    }

    public void Hide()
    {
        actionPanel.Toggle(false);
        gameObject.SetActive(false);
        ResetDraggedItem();
        PlaySoundShow();
    }

    internal void ResetAllItems()
    {
        foreach(var item in listOfUIItems)
        {
            item.ResetData();
            item.Deselect();
        }
    }
    
    private void PlaySoundShow()
    {
        eventInstance = RuntimeManager.CreateInstance(fmodEventPath);
        eventInstance.setParameterByName("Type", 3);
        eventInstance.start();
        eventInstance.release();
    }
}
