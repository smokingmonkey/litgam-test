using _LitgTest.Scripts.GameLogic.DataServices;
using _LitgTest.Scripts.GameLogic.Models.DataModels;
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

        private void Start()
        {
           InitPlayer(); 
        }

        void InitPlayer()
        {
            var savedPlayerData = PersistentDataService.GetElement<PlayerData>(DataModels.PlayerData);
            if (savedPlayerData == null) return;
            
            playerDataObj = savedPlayerData;
            
            PlayerAnimatorControllerSingleton.Instance.PlayAnimation(playerDataObj.danceAnimation.ToString());
        }
    }
}