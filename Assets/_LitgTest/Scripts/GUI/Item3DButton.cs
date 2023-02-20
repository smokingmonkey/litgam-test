using System;
using _LitgTest.Scripts.GameLogic.Models.GamePlayModels;
using _LitgTest.Scripts.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace _LitgTest.Scripts.GUI
{
    [RequireComponent(typeof(Button))]
    public class Item3DButton : MonoBehaviour
    {
        [SerializeField] private Color normalColor;
        [SerializeField] private Color selectedColor;

        [SerializeField] private Material pickedMaterial;

        [SerializeField] private Renderer renderer;

        int id;
        public int ID => id;

        public ItemType ThisItemType => thisItemType;

        [SerializeField] ItemType thisItemType;
        public Button elementButton;

        private void Awake()
        {
            elementButton = GetComponent<Button>();
        }

        private void OnEnable()
        {
            PickableItemController.ItemPicked += SetPickedColor;
        }

        private void OnDisable()
        {
            PickableItemController.ItemPicked -= SetPickedColor;
        }

        private void SetPickedColor(ItemType obj)
        {
            renderer.material = pickedMaterial;
        }


        public void ToggleSelectedColor(bool isSelected)
        {
            elementButton.image.color = isSelected ? selectedColor : normalColor;
        }
    }
}