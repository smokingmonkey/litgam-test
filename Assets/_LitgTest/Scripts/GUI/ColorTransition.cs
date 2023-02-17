using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _LitgTest.Scripts.GUI
{
    [RequireComponent(typeof(Image))]
    public class ColorTransition : MonoBehaviour
    {
        [SerializeField] Color startColor;
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

            while (image.material.color != targetColor)
            {
                tick += Time.deltaTime * speed;
                image.material.color = Color.Lerp(startColor, targetColor, Mathf.PingPong(Time.time, 1));
                yield return null;
            }
        }
    }
}