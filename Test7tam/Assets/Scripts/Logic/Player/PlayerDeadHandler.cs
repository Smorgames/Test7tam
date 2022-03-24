using Infrastructure;
using Logic.UniversalComponents;
using UnityEngine;

namespace Logic.Player
{
    public class PlayerDeadHandler : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private Health _health;
        [SerializeField] private GameObject _sliderCanvas;

        private void Awake() => 
            _health.OnDead += PlayerDead;

        private void OnDestroy() => 
            _health.OnDead -= PlayerDead;

        private void PlayerDead()
        {
            _movement.NullifySpeed();
            _movement.enabled = false;
            _sliderCanvas.SetActive(false);
            _animator.TriggerDead();
            _game.Restart();
        }
    }
}