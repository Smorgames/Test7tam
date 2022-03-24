using Infrastructure;
using Logic.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic.GameField
{
    public class EnemySpawner : MonoBehaviour
    {
        private const int MinX = 2;
        private const int MinY = 0;
        
        [SerializeField] private Game _game;
        [SerializeField, Range(1, 15)] private int _enemyAmount;
        [SerializeField] private GameObject _enemyPref;
        [SerializeField] private EnemyMoveField _enemyMoveField;

        private void Start()
        {
            for (var i = 0; i < _enemyAmount; i++) 
                SpawnEnemyInRandomPosition();

            _game.SetEnemyAmount(_enemyAmount);
        }

        private void SpawnEnemyInRandomPosition()
        {
            var x = Random.Range(MinX, _enemyMoveField.GetSize().x);
            var y = Random.Range(MinY, _enemyMoveField.GetSize().y);

            var enemy = SpawnEnemy(_enemyMoveField.GetPoint(x, y).position);
            InitializeEnemy(enemy, x, y);
        }

        private GameObject SpawnEnemy(Vector2 position) => 
            Instantiate(_enemyPref, position, Quaternion.identity);

        private void InitializeEnemy(GameObject enemy, int x, int y)
        {
            var enemyMovement = enemy.GetComponentInChildren<EnemyMovement>();
            enemyMovement.Initialize(_enemyMoveField, new Vector2Int(x, y), 2f);
            
            var enemyDeadHandler = enemy.GetComponentInChildren<EnemyDeadHandler>();
            enemyDeadHandler.Construct(_game);
        }
    }
}