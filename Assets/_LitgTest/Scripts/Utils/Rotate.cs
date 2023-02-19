using UnityEngine;

namespace _LitgTest.Scripts.Utils
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private float xSpeed; 
        [SerializeField] private float ySpeed; 
        [SerializeField] private float zSpeed; 

        // Update is called once per frame
        void Update()
        {
            var rotation = new Vector3(xSpeed, ySpeed, zSpeed);
        
            transform.Rotate(rotation * Time.deltaTime, Space.Self);
        }
    }
}