using System;
using System.Collections.Generic;
using _Andy.Scripts.Models;
using _Andy.Scripts.Weapons;
using UnityEngine;

namespace _Andy.Scripts.GUI
{
    public class ItemsUiController : MonoBehaviour
    {
        public event Action <ItemType> ItemValueChange;

        // [SerializeField] private List<ItemButton> itemButtons;
    
        [SerializeField] private List<ItemElement> itemElements;

        private void Start()
        {
            // foreach (var element in itemButtons)
            // {
            //     element.elementButton.onClick.AddListener(() => SetItem(element));
            // }
        }

        // private void ToggleSelectedColor(ItemButton itemButton)
        // {
        //     foreach (var element in itemButtons)
        //     {
        //         element.ToggleSelectedColor(false);
        //     }
        //     itemButton.ToggleSelectedColor(true);
        // }

        // private void OnDisable()
        // {
        //     foreach (var element in itemButtons)
        //     {
        //         element.elementButton.onClick.RemoveAllListeners();
        //     }
        // }
        //
        // void SetItem(ItemButton itemButton)
        // {
        //     var element = itemElements.Find(p => p.itemType == itemButton.ThisItemType);
        //     if (!element.isPicked) return;
        //     
        //     ToggleSelectedColor(itemButton);
        //     ItemValueChange?.Invoke(itemButton.ThisItemType);
        // }

      
    }
}