using System;
using System.Collections.Generic;
using _LitgTest.Scripts.Audio;
using _LitgTest.Scripts.GameLogic.Models.GamePlayModels;
using UnityEngine;

namespace _LitgTest.Scripts.Weapons
{
    public class PickableItemController : MonoBehaviour
    {
        public static event Action<ItemType> ItemPicked;
        public static event Action<ItemType> ItemSelected;

        [SerializeField] private List<ItemElement> itemElements;
        [SerializeField] private AudioController audioController;

        private void Update()
        {
            ToggleItemByInput();
        }

        void ToggleItemByInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ToggleItems(ItemType.WeaponA);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ToggleItems(ItemType.WeaponB);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ToggleItems(ItemType.WeaponC);
            }
        }

        void ToggleItems(ItemType itemType)
        {
            if (!GetItem(itemType).isPicked) return;

            ItemPicked?.Invoke(itemType);

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
                ItemPicked?.Invoke(ItemType.WeaponA);
                audioController.PlaySound();
            }

            if (other.CompareTag("WeaponB"))
            {
                Destroy(other.gameObject);
                GetItem(ItemType.WeaponB).isPicked = true;
                ToggleItems(ItemType.WeaponB);
                ItemPicked?.Invoke(ItemType.WeaponB);

                audioController.PlaySound();
            }

            if (other.CompareTag("WeaponC"))
            {
                Destroy(other.gameObject);
                GetItem(ItemType.WeaponC).isPicked = true;
                ToggleItems(ItemType.WeaponC);
                ItemPicked?.Invoke(ItemType.WeaponC);

                audioController.PlaySound();
            }
        }

        ItemElement GetItem(ItemType itemType)
        {
            return itemElements.Find(p => p.itemType == itemType);
        }
    }
}