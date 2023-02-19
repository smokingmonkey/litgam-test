using UnityEngine;

namespace _LitgTest.Scripts.Weapons
{
    public class FloorEarthquakeBehaviour : MonoBehaviour
    {
        private Renderer renderer;
        
        [SerializeField] private float resetMaterialTime;

        [SerializeField] private Material floor;
        [SerializeField] private Material earthquake;

        void Start()
        {
            renderer = GetComponent<Renderer>();
        }

        public void SetEarthquakeMaterial()
        {
            renderer.material = earthquake;
            Invoke(nameof(SetFloorMaterial), resetMaterialTime);
        }

        public void SetFloorMaterial()
        {
            renderer.material = floor;
        }
    }
}