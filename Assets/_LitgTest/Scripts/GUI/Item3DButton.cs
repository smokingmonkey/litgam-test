using _LitgTest.Scripts.GameLogic.Models.GamePlayModels;
using _LitgTest.Scripts.Weapons;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _LitgTest.Scripts.GUI
{
    public class Item3DButton : MonoBehaviour
    {
        [SerializeField] private Material pickedMaterial;
        [SerializeField] private Material selectedMaterial;

        [SerializeField] private Renderer elementRenderer;

        int id;
        public int ID => id;

        private bool isPicked;

        public ItemType ThisItemType => thisItemType;

        [SerializeField] ItemType thisItemType;
        public Button elementButton;

        private void Awake()
        {
            elementButton = GetComponent<Button>();
        }

        private void OnEnable()
        {
            PickableItemController.ItemPicked += SetMaterial;
        }

        private void OnDisable()
        {
            PickableItemController.ItemPicked -= SetMaterial;
        }

        private void SetMaterial(ItemType obj)
        {
            if (obj == thisItemType)
            {
                isPicked = true;
                elementRenderer.material = selectedMaterial;
            }
            else if (isPicked)
            {
                elementRenderer.material = pickedMaterial;
            }
        }


        public void ToggleSelectedColor(bool isSelected)
        {
            elementRenderer.material = isSelected ? selectedMaterial : pickedMaterial;
        }
    }
}