using Infrastructure;
using Logic.UniversalComponents;
using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyDeadHandler : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private Collider2D _collider;

        private Game _game;

        private void Awake() => 
            _health.OnDead += EnemyDead;

        private void OnDestroy() => 
            _health.OnDead -= EnemyDead;

        public void Construct(Game game) =>
            _game = game;

        private void EnemyDead()
        {
            _movement.enabled = false;
            _collider.enabled = false;
            _game.EnemyDead();
            _animator.TriggerDead();
        }
    }
}
