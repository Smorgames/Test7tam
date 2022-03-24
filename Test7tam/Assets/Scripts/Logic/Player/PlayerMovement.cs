using Infrastructure;
using UnityEngine;

namespace Logic.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        [SerializeField] private Game _game;
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _speed;

        private Vector2 _inputAxis;

        private void Update()
        {
            _inputAxis = _game.GetInputService().GetAxis();
            _animator.SetSpeed(_inputAxis.magnitude);
        }

        private void FixedUpdate() => 
            _rigidBody.velocity = _inputAxis * _speed * Time.fixedDeltaTime;

        public Vector2 GetAxis() => _inputAxis;

        public void NullifySpeed() => _rigidBody.velocity = Vector2.zero;
    }
}