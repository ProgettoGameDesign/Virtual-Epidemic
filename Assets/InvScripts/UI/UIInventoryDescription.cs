using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Inventory.Model;

namespace Inventory.UI
{
    public class UIInventoryDescription : MonoBehaviour, IDragHandler
    {
        [SerializeField]
        private Image itemImage;
        [SerializeField]
        private TMP_Text title;
        [SerializeField]
        private TMP_Text description;

        private Transform itemPrefab;

        public void Awake()
        {
            ResetDescription();
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("sto muovendo inizio");
            itemPrefab.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x);
            Debug.Log("sto muovendo fine");
        }

        public void ResetDescription()
        {
            itemImage.gameObject.SetActive(false);
            title.text = "";
            description.text = "";
        }
        public void SetDescription(Sprite sprite, ItemSO itemSO, string itemName, string itemDescription)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = sprite;
            if (itemPrefab != null)
            {
                Destroy(itemPrefab.gameObject);
            }
            itemPrefab = Instantiate(itemSO.prefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
            title.text = itemName;
            description.text = itemDescription;
        }


    }
}