using _LitgTest.Scripts.Models;
using _LitgTest.Scripts.Models.AnimationModels;
using UnityEngine;

namespace _LitgTest.Scripts.Character.Player.Controllers
{
    public class CharacterAnimatorController : MonoBehaviour
    {
        private Animator playerAnimator;

        void Start()
        {
            playerAnimator = GetComponent<Animator>();
        }

        public void PlayAnimation(PlayerAnimations playerAnimations)
        {
            if (!playerAnimator) return;
            playerAnimator.SetBool(playerAnimations.ToString(), true);
        }

        public void StopAnimation(PlayerAnimations playerAnimations)
        {
            if (!playerAnimator) return;
            playerAnimator.SetBool(playerAnimations.ToString(), false);
        }
        
        public void SetTrigger(PlayerAnimations playerAnimations)
        {
            if (!playerAnimator) return;
            
            playerAnimator.SetTrigger(playerAnimations.ToString());
        }

    }
}
