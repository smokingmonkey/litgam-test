using _LitgTest.Scripts.GameLogic.DataServices;
using _LitgTest.Scripts.GameLogic.Models.DataModels;
using _LitgTest.Scripts.GUI;
using _LitgTest.Scripts.Models.AnimationModels;
using UnityEngine;

namespace _LitgTest.Scripts.Character.Player.Controllers
{
    public class PlayerControllerSingleton : MonoBehaviour
    {
        public static PlayerControllerSingleton Instance { get; private set; }

        private PlayerData playerDataObj;

        public PlayerData PlayerDataObj => playerDataObj;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }
        
        private void OnEnable()
        {
            AnimationSelectorButton.AnimationSelected += SetCurrentAnimationData;
        }
        
        private void OnDisable()
        {
            AnimationSelectorButton.AnimationSelected -= SetCurrentAnimationData;
        }

        void SetCurrentAnimationData(PlayerDances dance)
        {
            playerDataObj.danceAnimation = dance;
        }

        private void Start()
        {
           InitPlayer(); 
        }

        void InitPlayer()
        {
            playerDataObj = new PlayerData();
            
            var savedPlayerData = PersistentDataService.GetElement<PlayerData>(DataModels.PlayerData);
            
            if (savedPlayerData == null) return;
            
            playerDataObj = savedPlayerData;
        }
    }
}