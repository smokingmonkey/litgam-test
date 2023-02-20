using UnityEngine;

namespace _LitgTest.Scripts.Weapons
{
    public class FloorEarthquakeBehaviour : MonoBehaviour
    {
        private Renderer objRenderer;

        [SerializeField] private float resetMaterialTime;

        [SerializeField] private Material floor;
        [SerializeField] private Material earthquake;


        void Start()
        {
            objRenderer = GetComponent<Renderer>();
        }


        public void SetEarthquakeMaterial()
        {
            objRenderer.material = earthquake;

            Invoke(nameof(SetFloorMaterial), resetMaterialTime);
        }

        public void SetFloorMaterial()
        {
            objRenderer.material = floor;
        }
    }
}