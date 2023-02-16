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

        public void PlayAnimation(PlayerDances playerDances)
        {
            if (!playerAnimator) return;
            playerAnimator.Play(playerDances.ToString());
        }

        public void StopAnimation(PlayerDances playerDances)
        {
            if (!playerAnimator) return;
            playerAnimator.SetBool(playerDances.ToString(), false);
        }
        
        public void SetTrigger(PlayerDances playerDances)
        {
            if (!playerAnimator) return;
            
            playerAnimator.SetTrigger(playerDances.ToString());
        }

    }
}
