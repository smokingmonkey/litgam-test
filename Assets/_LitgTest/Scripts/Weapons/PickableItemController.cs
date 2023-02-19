using System.Collections.Generic;
using _Andy.Scripts.Models;
using _Andy.Scripts.Weapons;
using _LitgTest.Scripts.Audio;
using UnityEngine;

namespace _LitgTest.Scripts.Weapons
{
    public class PickableItemController : MonoBehaviour
    {
        // [SerializeField] private ItemsUiController itemsUiController;

        [SerializeField] private List<ItemElement> itemElements;
        [SerializeField] private AudioController audioController;

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
            if (other.CompareTag("WeaponA"))
            {
                Destroy(other.gameObject);
                GetItem(ItemType.WeaponA).isPicked = true;
                ToggleItems(ItemType.WeaponA);
                
                audioController.PlaySound();
            }

            if (other.CompareTag("WeaponB"))
            {
                Destroy(other.gameObject);
                GetItem(ItemType.WeaponB).isPicked = true;
                ToggleItems(ItemType.WeaponB);
                
                audioController.PlaySound();

            }

            if (other.CompareTag("WeaponC"))
            {
                Destroy(other.gameObject);
                GetItem(ItemType.WeaponC).isPicked = true;
                ToggleItems(ItemType.WeaponC);
                
                audioController.PlaySound();

            }
        }

        ItemElement GetItem(ItemType itemType)
        {
            return itemElements.Find(p => p.itemType == itemType);
        }
    }
}