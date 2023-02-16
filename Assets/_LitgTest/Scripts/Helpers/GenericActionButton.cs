using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _LitgTest.Scripts.Helpers
{
    public abstract class  GenericActionButton : MonoBehaviour,  IPointerUpHandler, IPointerDownHandler,
        IPointerExitHandler
    {
        public event Action PointerDown;
        public event Action PointerUp;

      

        public void OnPointerUp(PointerEventData eventData)
        {
            PointerUp?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDown?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerUp?.Invoke();
        }
    }
}