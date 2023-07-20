using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Base
{
    public class SetterDirection : MonoBehaviour, IBeginDragHandler,IDragHandler
    {
        public event Action<Vector2> OnChangeDirection;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                OnChangeDirection?.Invoke(eventData.delta.x > 0 ? Vector2.right : Vector2.left);

            }
            else
            {
                OnChangeDirection?.Invoke(eventData.delta.y > 0 ? Vector2.up : Vector2.down);

            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }
    }
}