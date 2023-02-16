using System;
using _LitgTest.Scripts.Character.Player.Controllers;
using _LitgTest.Scripts.Helpers;
using _LitgTest.Scripts.Models.AnimationModels;
using UnityEngine;
using UnityEngine.UI;

namespace _LitgTest.Scripts.GUI
{
    public class AnimationSelectorButton : Button
    {
        [Tooltip("Set the animation that this button should trigger")]
        [SerializeField] private PlayerAnimations playerAnimation;

        new void OnEnable()
        {
            onClick.AddListener(SetAnimation);
        }

        new void OnDisable()
        {
            onClick.RemoveListener(SetAnimation);
        }
        private void SetAnimation()
        {
            PlayerAnimatorControllerSingleton.Instance.PlayAnimation(playerAnimation);
        }
    }
}
