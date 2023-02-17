using System;
using _LitgTest.Scripts.GUI;
using _LitgTest.Scripts.Models.AnimationModels;
using UnityEngine;

namespace _LitgTest.Scripts.Character.Player.Controllers
{
    public class PlayerAnimatorControllerSingleton : CharacterAnimatorController
    {
        public static PlayerAnimatorControllerSingleton Instance { get; private set; }

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
            AnimationSelectorButton.AnimationSelected += Play;
        }

        private void OnDisable()
        {
            AnimationSelectorButton.AnimationSelected -= Play;
        }

        public void Play(PlayerDances dance)
        {
            PlayAnimation(dance.ToString());
        }
    }
}