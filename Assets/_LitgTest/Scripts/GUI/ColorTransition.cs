using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _LitgTest.Scripts.GUI
{
    [RequireComponent(typeof(Image))]
    public class ColorTransition : MonoBehaviour
    {
        [SerializeField] Color targetColor;

        [SerializeField] private float speed;
        float timeLeft;

        private Image image;

        private void Start()
        {
            image = GetComponent<Image>();

            StartCoroutine(ChangeEngineColour());
        }


        private IEnumerator ChangeEngineColour()
        {
            float tick = 0f;
            
            Debug.Log("ssss" + (image.material.color != targetColor));


            while (image.material.color != targetColor)
            {

                tick += Time.deltaTime * speed;
                image.material.color = Color.Lerp(image.material.color, targetColor, tick);
                yield return null;
            }
        }
    }
}