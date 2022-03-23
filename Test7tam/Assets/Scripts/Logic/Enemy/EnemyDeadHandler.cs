using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyDeadHandler : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private EnemyMovement _movement;

        private void Awake() => 
            _health.OnDead += EnemyDead;

        private void OnDestroy() => 
            _health.OnDead -= EnemyDead;

        private void EnemyDead()
        {
            _movement.enabled = false;
            _animator.TriggerDead();
        }
    }
}
