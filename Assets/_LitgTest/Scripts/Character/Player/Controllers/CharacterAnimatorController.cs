using _LitgTest.Scripts.Models;
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

        public void PlayAnimation(Animations animations)
        {
            if (!playerAnimator) return;
            playerAnimator.SetBool(animations.ToString(), true);
        }

        public void StopAnimation(Animations animations)
        {
            if (!playerAnimator) return;
            playerAnimator.SetBool(animations.ToString(), false);
        }
        
        public void SetTrigger(Animations animations)
        {
            if (!playerAnimator) return;
            
            playerAnimator.SetTrigger(animations.ToString());
        }

    }
}
