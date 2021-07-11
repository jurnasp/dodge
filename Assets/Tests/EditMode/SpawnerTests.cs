using System;
using Library.Enemy.Spawner;
using NSubstitute;
using NUnit.Framework;

namespace Tests.EditMode
{
    public class SpawnerTests
    {
        private IEnemySpawnTimer _spawnTimer;
        private IEnemyCreator _enemyCreator;
        private Spawner _spawner;

        [SetUp]
        public void Setup()
        {
            _spawnTimer = Substitute.For<IEnemySpawnTimer>();
            _enemyCreator = Substitute.For<IEnemyCreator>();
            _spawner = new Spawner(_enemyCreator, _spawnTimer);   
        }
        
        [Test]
        public void WhenNotIsLongPauseAndNotIsPause_PauseInvoked()
        {
            ExpectIsLongPause(false);
            ExpectIsPause(false);
            
            _spawner.Tick(0f);
            
            _spawnTimer.ReceivedWithAnyArgs().InvokePause();
        }
        
        [Test]
        public void WhenIsGameEnd_PauseNotInvoked()
        {
            ExpectGameHasEnded();
            ExpectIsLongPause(false);
            ExpectIsPause(false);
            
            _spawner.Tick(0f);
            
            _spawnTimer.DidNotReceiveWithAnyArgs().InvokePause();
        }
        
        [Test]
        public void WhenIsLongPauseAndCanIncreaseDifficulty_LongPauseInvoked()
        {
            ExpectIsLongPause(false);
            ExpectCanIncreaseDifficulty();

            _spawner.Tick(0f);
            
            _spawnTimer.ReceivedWithAnyArgs().InvokeLongPause();
        }
        
        [Test]
        public void WhenIsGameEnd_LongPauseNotInvoked()
        {
            ExpectGameHasEnded();
            ExpectIsLongPause(false);
            ExpectCanIncreaseDifficulty();

            _spawner.Tick(0f);
            
            _spawnTimer.DidNotReceiveWithAnyArgs().InvokeLongPause();
        }
        
        [Test]
        public void WhenEndGameCalled_GameEndDelegatedToTimerAndCreator()
        {
            _spawner.EndGame();
            
            _spawnTimer.Received().OnGameEnd();
            _enemyCreator.Received().OnGameEnd();
        }
        
        [Test]
        public void WhenLongPauseCalledAndArgumentsInvoked_IncreaseDifficultyCalledOnTimerAndCreator()
        {
            ExpectIsLongPause(false);
            ExpectCanIncreaseDifficulty();
            
            _spawnTimer.InvokeLongPause(Arg.Do<Action[]>(x => { 
                foreach (var action in x)
                    action.Invoke(); 
            }));
            _spawner.Tick(0f);

            _spawnTimer.Received().IncreaseDifficulty();
            _enemyCreator.Received().IncreaseDifficulty();
        }

        private void ExpectIsPause(bool expect = true, int spawnCount = 0)
        {
            _spawnTimer.IsPause().Returns(expect);
        }

        private void ExpectIsLongPause(bool expect = true, int spawnCount = 0)
        {
            _spawnTimer.IsLongPause().Returns(expect);
        }

        private void ExpectCanIncreaseDifficulty(bool expect = true, int spawnCount = 0)
        {
            _spawnTimer.CanIncreaseDifficulty(spawnCount).Returns(expect);
        }

        private void ExpectGameHasEnded(bool expect = true)
        {
            _spawnTimer.IsGameEnd().Returns(expect);
        }
    }
}
