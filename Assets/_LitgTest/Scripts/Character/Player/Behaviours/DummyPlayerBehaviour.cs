using _LitgTest.Scripts.Character.Player.Controllers;
using _LitgTest.Scripts.GameLogic.DataServices;
using _LitgTest.Scripts.GameLogic.Models.DataModels;
using _LitgTest.Scripts.Models.AnimationModels;
using UnityEngine;

namespace _LitgTest.Scripts.Character.Player.Behaviours
{
    [RequireComponent(typeof(CharacterAnimatorController))]
    public class DummyPlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerDances defaultDance;
        [SerializeField] private CharacterAnimatorController animatorController;

        protected void Start()
        {
            var savedPlayerData = PersistentDataService.GetElement<PlayerData>(DataModels.PlayerData);

            if (savedPlayerData == null)
            {
                animatorController.PlayAnimation(defaultDance.ToString());
                return;
            }

            animatorController.PlayAnimation(savedPlayerData.danceAnimation.ToString());
        }
    }
}