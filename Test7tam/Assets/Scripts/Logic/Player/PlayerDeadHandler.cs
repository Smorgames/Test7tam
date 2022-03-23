using UnityEngine;

namespace Logic.Player
{
    public class PlayerDeadHandler : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private Health _health;

        private void Awake() => 
            _health.OnDead += PlayerDead;

        private void OnDestroy() => 
            _health.OnDead -= PlayerDead;

        private void PlayerDead()
        {
            _movement.enabled = false;
            _animator.TriggerDead();
        }
    }
}