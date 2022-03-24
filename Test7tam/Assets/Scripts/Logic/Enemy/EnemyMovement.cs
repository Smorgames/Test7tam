using Logic.GameField;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        private const float Threshold = 0.001f;
        private const float MinRandom = 0f;
        private const float MaxRandom = 1f;
        private const float HalfRandom = 0.5f;

        [SerializeField] private EnemyRotator _rotator;
        [SerializeField] private Transform _movingObject;
        [SerializeField] private EnemyMoveField _moveField;
        
        private Vector2Int _currentCoordinates;
        private float _speed;
        private bool _initialized;

        private void Update()
        {
            if (!_initialized)
                return;
        
            MoveToPoint();

            if (EnemyReachPoint())
                SetRandomMoveDirection();
        }

        public void Initialize(EnemyMoveField moveField, Vector2Int coordinates, float speed)
        {
            _moveField = moveField;
            _currentCoordinates = coordinates;
            _speed = speed;
            _initialized = true;
        }

        private void MoveToPoint()
        {
            var newPosition = Vector2.MoveTowards(
                _movingObject.position,
                _moveField.GetPoint(_currentCoordinates).position,
                _speed * Time.deltaTime);

            var moveDirection = newPosition - (Vector2)_movingObject.position;
            _rotator.SetRotationBasedOn(moveDirection);

            _movingObject.position = newPosition;
        }

        private bool EnemyReachPoint() => 
            Vector2.Distance(_movingObject.position, _moveField.GetPoint(_currentCoordinates).position) < Threshold;

        private void SetRandomMoveDirection()
        {
            var horizontalAxis = RandomBoolean();

            var targetCoordinate = horizontalAxis
                ? Random.Range(0, _moveField.GetSize().x)
                : Random.Range(0, _moveField.GetSize().y);

            var x = horizontalAxis ? targetCoordinate : _currentCoordinates.x;
            var y = horizontalAxis ? _currentCoordinates.y : targetCoordinate;

            _currentCoordinates = new Vector2Int(x, y);
        }

        private bool RandomBoolean() =>
            Random.Range(MinRandom, MaxRandom) > HalfRandom;
    }
}