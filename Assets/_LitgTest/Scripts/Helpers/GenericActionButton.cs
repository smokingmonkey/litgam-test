using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _LitgTest.Scripts.Helpers
{
    public abstract class  GenericActionButton : Button,  IPointerUpHandler, IPointerDownHandler,
        IPointerExitHandler
    {
        public event Action PointerDown;
        public event Action PointerUp;

      

        public override void OnPointerUp(PointerEventData eventData)
        {
            PointerUp?.Invoke();
        }

        public new void OnPointerDown(PointerEventData eventData)
        {
            PointerDown?.Invoke();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            PointerUp?.Invoke();
        }
    }
}