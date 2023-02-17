using _LitgTest.Scripts.Character.Player.Controllers;
using _LitgTest.Scripts.Models.AnimationModels;
using UnityEngine;
using UnityEngine.UI;

namespace _LitgTest.Scripts.GUI
{
    [RequireComponent(typeof(Button))]
    public class AnimationSelectorButton : MonoBehaviour
    {
        [Tooltip("Set the animation that this button should trigger")] [SerializeField]
        private PlayerDances playerDance;

        Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        void OnEnable()
        {
            button.onClick.AddListener(SetAnimation);
        }

        void OnDisable()
        {
            button.onClick.RemoveListener(SetAnimation);
        }

        private void SetAnimation()
        {
            PlayerControllerSingleton.Instance.PlayerDataObj.danceAnimation = playerDance;
            PlayerAnimatorControllerSingleton.Instance.PlayAnimation(playerDance.ToString());
        }
    }
}