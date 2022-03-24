using System;
using UnityEngine;

namespace Logic.UniversalComponents
{
    public class Health : MonoBehaviour
    {
        public Action OnDead;
    
        [SerializeField] private int _maxHealth;
        private int _health;

        private void Awake() => 
            _health = _maxHealth;

        public void TakeOneDamage()
        {
            _health--;

            if (_health <= 0)
                OnDead?.Invoke();
        }
    }
}