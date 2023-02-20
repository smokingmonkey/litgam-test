using System;
using System.Collections.Generic;
using _LitgTest.Scripts.GameLogic.Models.GamePlayModels;
using UnityEngine;

namespace _LitgTest.Scripts.GUI
{
    public class ItemsUiController : MonoBehaviour
    {
        public event Action <ItemType> ItemValueChange;

        [SerializeField] private List<Item3DButton> itemButtons;

        [SerializeField] private List<ItemElement> itemElements;

        private void Start()
        {
            foreach (var element in itemButtons)
            {
                element.elementButton.onClick.AddListener(() => SetItem(element));
            }
        }

        private void ToggleSelectedColor(Item3DButton item3DButton)
        {
            foreach (var element in itemButtons)
            {
                element.ToggleSelectedColor(false);
            }
            item3DButton.ToggleSelectedColor(true);
        }

        private void OnDisable()
        {
            foreach (var element in itemButtons)
            {
                element.elementButton.onClick.RemoveAllListeners();
            }
        }

        void SetItem(Item3DButton item3DButton)
        {
            var element = itemElements.Find(p => p.itemType == item3DButton.ThisItemType);
            if (!element.isPicked) return;
            
            ToggleSelectedColor(item3DButton);
            ItemValueChange?.Invoke(item3DButton.ThisItemType);
        }

      
    }
}