using System;
using UnityEngine;

namespace Logic.UniversalComponents
{
    public class InteractionObserver : MonoBehaviour
    {
        public Action<Collider2D> TriggerEnter2D;
        
        private void OnTriggerEnter2D(Collider2D col) => 
            TriggerEnter2D?.Invoke(col);
    }
}
