namespace Enemy
{
    public class EnemyCreatorModel
    {
        public int CreatedEnemyCount { get; private set; }

        public void CreateEnemy()
        {
            CreatedEnemyCount++;
        }
    }
}