using System.Collections.Generic;
using _Andy.Scripts.Models;
using _Andy.Scripts.Weapons;
using UnityEngine;

namespace _Andy.Scripts.Characters
{
    public class ItemsController : MonoBehaviour
    {
        // [SerializeField] private ItemsUiController itemsUiController;

        [SerializeField] private List<ItemElement> itemElements;

        private void OnEnable()
        {
            // itemsUiController.ItemValueChange += ToggleItems;
        }

        void ToggleItems(ItemType itemType)
        {
            foreach (var itemElement in itemElements)
            {
                itemElement.gameObject.SetActive(false);
            }

            GetItem(itemType).gameObject.SetActive(true);
        
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("SheriffKey"))
            {
                Destroy(other.gameObject);
                GetItem(ItemType.SpecialItemA).isPicked = true;
                
            }
            if (other.CompareTag("WeaponB"))
            {
                Destroy(other.gameObject);
                GetItem(ItemType.WeaponB).isPicked = true;
            }
            
        }

        ItemElement GetItem(ItemType itemType)
        {
            return itemElements.Find(p => p.itemType == itemType);
        }
    }
}