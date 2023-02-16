using TMPro;
using UnityEngine;

namespace _LitgTest.Scripts.GUI
{
    [RequireComponent(typeof(TMP_Text))]
    public class GuiCountDown : MonoBehaviour
    {
        private TMP_Text counterText;

        [SerializeField] private float coolDownTime;
        private float counter;

        private void OnEnable()
        {
            counterText = GetComponent<TMP_Text>();
            counterText.SetText(coolDownTime.ToString());
        }

        void Update()
        {
            if (counter <= 0f) counter = coolDownTime;

            counter -= Time.deltaTime;
            counterText.SetText(counter.ToString("F0"));
        }
    }
}