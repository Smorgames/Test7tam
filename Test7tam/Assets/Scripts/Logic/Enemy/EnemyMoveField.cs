using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyMoveField : MonoBehaviour
    {
        [SerializeField, Range(0, 10000)] private int _length;
        [SerializeField, Range(0, 10000)] private int _height;

        private Transform[,] _movePoints;

        private void Start() => 
            InitMovePoints();

        public Vector2Int GetSize() => new Vector2Int(_length, _height);

        public Transform GetPoint(Vector2Int coordinate) => _movePoints[coordinate.x, coordinate.y];

        private void InitMovePoints()
        {
            _movePoints = new Transform[_length, _height];
        
            for (var i = 0; i < transform.childCount; i++)
            {
                var x = i % _length;
                var y = i / _length;

                _movePoints[x, y] = transform.GetChild(i);
            }
        
            //Utils.DebugTwoDimensionArray(_movePoints);
        }
    }
}