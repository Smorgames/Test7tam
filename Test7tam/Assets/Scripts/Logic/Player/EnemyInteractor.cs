using Logic.UniversalComponents;
using UnityEngine;

namespace Logic.Player
{
    public class EnemyInteractor : MonoBehaviour
    {
        private const string EnemyTag = "Enemy";
        
        [SerializeField] private InteractionObserver _interactionObserver;
        [SerializeField] private Health _health;

        private void Awake() =>
            _interactionObserver.TriggerEnter2D += TriggerEnter2D;

        private void OnDestroy() => 
            _interactionObserver.TriggerEnter2D -= TriggerEnter2D;

        private void TriggerEnter2D(Collider2D col)
        {
            var enemy = col.CompareTag(EnemyTag);
            
            if (enemy)
                _health.TakeOneDamage();
        }
    }
}