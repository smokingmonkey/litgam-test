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
    }
}