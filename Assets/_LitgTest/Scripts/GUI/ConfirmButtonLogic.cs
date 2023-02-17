using _LitgTest.Scripts.Character.Player.Controllers;
using _LitgTest.Scripts.GameLogic;
using _LitgTest.Scripts.GameLogic.DataServices;
using _LitgTest.Scripts.GameLogic.Models.DataModels;
using _LitgTest.Scripts.Models.AnimationModels;
using UnityEngine;
using UnityEngine.UI;

namespace _LitgTest.Scripts.GUI
{
    [RequireComponent(typeof(Button))]
    public class ConfirmButtonLogic : MonoBehaviour
    {
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        private void Start()
        {
            //Player should continue only if an animation has been already chosen 
            button.interactable = false;
            
            //Player should continue only if an animation has been already chosen  
            AnimationSelectorButton.AnimationSelected += OnAnimationSelected;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(ConfirmSelection);
            
            
        }

        private void OnAnimationSelected(PlayerDances obj)
        {
            button.interactable = true;
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(ConfirmSelection);
        }

        //Set all the current implemented data about the player (animations, character selection, etc) in an object of type "PlayerData" 
        void ConfirmSelection()
        {
            var player = PlayerControllerSingleton.Instance.PlayerDataObj;
            if (player == null) return;
            
            PersistentDataService.SaveElement(DataModels.PlayerData,
              player);
            
            SceneLoaderSingleton.Instance.LoadNext();
        }
    }
}