namespace Infrastructure
{
    public class GameReloader
    {
        private readonly Game _game;
        
        private int _enemyAmount;

        public GameReloader(Game game) => 
            _game = game;

        public void SetEnemyAmount(int amount) => 
            _enemyAmount = amount;

        public void EnemyDead()
        {
            _enemyAmount--;

            if (_enemyAmount == 0)
            {
                _game.Restart();
            }
        }
    }
}