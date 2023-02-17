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

        public void PlayAnimation(string animationName)
        {
            if (!playerAnimator) return;

            playerAnimator.Play(animationName);
        }

        public void StopAnimation(string animationName)
        {
            if (!playerAnimator) return;
            playerAnimator.SetBool(animationName, false);
        }

        public void SetTrigger(string animationName)
        {
            if (!playerAnimator) return;

            playerAnimator.SetTrigger(animationName);
        }

    }
}