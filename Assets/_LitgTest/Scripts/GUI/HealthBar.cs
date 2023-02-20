using UnityEngine;
using UnityEngine.UI;

namespace _LitgTest.Scripts.GUI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
   
        public void SetHealthBarValue(float value)
        {
            healthBar.fillAmount = value;
        }
    }
}