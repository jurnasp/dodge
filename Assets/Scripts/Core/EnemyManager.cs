using System.Collections.Generic;
using Dodge.Game;
using Dodge.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Dodge.Core
{
    public class EnemyManager : MonoBehaviour
    {
        public GameObject scoreCounter;
        public GameObject scoreAdder;

        public GameObject left;
        public GameObject leftTrail;
        public GameObject right;
        public GameObject rightTrail;

        public GameObject endPanel;
        public GameObject pauseButton;

        [FormerlySerializedAs("obstacleList")] [SerializeField]
        public List<Rigidbody> enenmyList;

        [FormerlySerializedAs("Cube")] public Rigidbody cube;
        public Rigidbody bigCube;
        public Rigidbody twoCube;
        public Rigidbody bigMiddleCube;

        public int difficulty;

        public float addSpeed;
        public float timeAdd;


        // private bool _isTutorial = false;
        public GameObject tutorialRightText;
        public GameObject tutorialLeftText;
        public GameObject tutorialSplitText;
        public GameObject tutorialLostPanel;
        public GameObject tutorialLostPanelEasy;
        private float _addTime;
        private float _holdTimer;
        private LoseTrigger _leftFreeze;
        private readonly float _offset = 6.6f;
        private float _pause = 2.5f;
        private float _pauseTimer;
        private LoseTrigger _rightFreeze;
        private ScoreAdd _scoreRead;

        private CountScore _spawnCount;
        private float _speed;

        private bool _stop;

        private float _timer;

        private readonly float addTimeEasy = 1.75f;
        private readonly float addTimeHard = 1.25f;
        private readonly float addTimeNormal = 1.5f;

        private readonly float pauseEasy = 3.5f;
        private readonly float pauseHard = 2.5f;
        private readonly float pauseNormal = 2f;

        private readonly float speedAddEasy = 3f;
        private readonly float speedAddHard = 4f;
        private readonly float speedAddNormal = 3.5f;


        private readonly float speedEasy = -8f;
        private readonly float speedHard = -15f;

        private readonly float speedNormal = -12f;
        // private float _delay = 2f;
        // private float _delayTwo = 3.5f;

        public void Start()
        {
            _timer = Time.time;
            timeAdd = 0.10f;

            _scoreRead = scoreAdder.GetComponent<ScoreAdd>();
            _spawnCount = scoreCounter.GetComponent<CountScore>();
            _leftFreeze = left.GetComponent<LoseTrigger>();
            _rightFreeze = right.GetComponent<LoseTrigger>();
            // _buttonIsPressed = left.GetComponent<ControlLeft>();

            LoadDifficultyConfigurations();
            LoadTrailConfiguration();
        }

        public void Update()
        {
            if (!IsTutorialEnabled())
            {
                // Tutorial();
            }

            if (IsLose())
            {
                endPanel.SetActive(true);
                pauseButton.SetActive(false);
                return;
            }

            if (!IsSpawnCyclePause()) return;
            if (!_stop)
            {
                _addTime -= timeAdd;
                _speed -= addSpeed;
                _stop = true;
            }
            else if (CanSpawnEnemy())
            {
                SpawnRandomEnemy();
                _timer = Time.time + _addTime;
            }

            if (IsFullCycleSpawned()) InvokeSpawnCyclePause();
        }

        private void InvokeSpawnCyclePause()
        {
            _pauseTimer = Time.time + _pause;
            _stop = false;
        }

        private bool CanSpawnEnemy()
        {
            return _timer < Time.time;
        }

        private bool IsFullCycleSpawned()
        {
            return false;
        }


        private void SpawnCubeMid()
        {
            var clone = Instantiate(cube, transform.position, cube.transform.rotation);
            clone.velocity = transform.up * _speed;
        }

        private void SpawnBigCubeMid()
        {
            var clone = Instantiate(bigMiddleCube, transform.position, cube.transform.rotation);
            clone.velocity = transform.up * _speed;
        }

        private void SpawnCubeLeft()
        {
            var spawnerPosition = transform.position;
            var clone = Instantiate(cube, new Vector3(spawnerPosition.x - _offset, spawnerPosition.y),
                cube.transform.rotation);
            clone.velocity = transform.up * _speed;
        }

        private void SpawnCubeRight()
        {
            var spawnerPosition = transform.position;
            var clone = Instantiate(cube, new Vector3(spawnerPosition.x + _offset, spawnerPosition.y),
                cube.transform.rotation);
            clone.velocity = transform.up * _speed;
        }

        private void SpawnBigCubeRight()
        {
            var spawnerPosition = transform.position;
            var clone = Instantiate(bigCube, new Vector3(spawnerPosition.x + _offset, spawnerPosition.y),
                cube.transform.rotation);
            clone.velocity = transform.up * _speed;
        }

        private void SpawnBigCubeLeft()
        {
            var spawnerPosition = transform.position;
            var clone = Instantiate(bigCube, new Vector3(spawnerPosition.x - _offset, spawnerPosition.y),
                cube.transform.rotation);
            clone.velocity = transform.up * _speed;
        }

        private void SpawnCubeTwo()
        {
            var spawner = transform;
            var clone = Instantiate(twoCube, spawner.position, spawner.rotation);
            clone.velocity = transform.up * _speed;
        }

        public void Retry()
        {
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("TotalTries", PlayerPrefs.GetInt("TotalTries", 0) + 1);
        }

        // private void Tutorial()
        // {
        //     if(_leftFreeze.lost | _rightFreeze.lost)
        //     {
        //         tutorialRightText.SetActive(false);
        //         tutorialLeftText.SetActive(false);
        //         tutorialSplitText.SetActive(false);
        //
        //         if (_holdTimer + _delayTwo < Time.time & _isTutorial)
        //         {
        //             SceneManager.LoadScene(1);
        //         }
        //         else if(PlayerPrefs.GetInt("DifficultyOption", 0) == 0 & !_isTutorial)
        //         {
        //             tutorialLostPanelEasy.SetActive(true);
        //             _holdTimer = Time.time;
        //             _isTutorial = true;
        //         }
        //         else if(PlayerPrefs.GetInt("DifficultyOption", 0) != 0 & !_isTutorial)
        //         {
        //             tutorialLostPanel.SetActive(true);
        //             PlayerPrefs.SetInt("DifficultyOption", 0);
        //             _holdTimer = Time.time;
        //             _isTutorial = true;
        //         }
        //     }
        //     else if (_spawnCount.spawnCount == 0)
        //     {
        //         tutorialRightText.SetActive(true);
        //         if (!_buttonIsPressed.rightIsPressed)
        //         {
        //             _holdTimer = Time.time;
        //         }
        //         else if (_buttonIsPressed.rightIsPressed)
        //         {
        //             if (_holdTimer + _delay < Time.time)
        //             {
        //                 SpawnBigCubeLeft();
        //             }
        //         }
        //     }
        //     else if (_scoreRead.score == 1 & _spawnCount.spawnCount == 1)
        //     {
        //         tutorialRightText.SetActive(false);
        //         tutorialLeftText.SetActive(true);
        //         if (!_buttonIsPressed.leftIsPressed)
        //         {
        //             _holdTimer = Time.time;
        //         }
        //         else if (_buttonIsPressed.leftIsPressed)
        //         {
        //             if (_holdTimer + _delay < Time.time)
        //             {
        //                 SpawnBigCubeRight();
        //                 _holdTimer = Time.time;
        //             }
        //         }
        //     }
        //     else if (_scoreRead.score == 2 & _spawnCount.spawnCount == 2)
        //     {
        //         tutorialLeftText.SetActive(false);
        //         tutorialSplitText.SetActive(true);
        //         if (!_buttonIsPressed.rightIsPressed | !_buttonIsPressed.leftIsPressed)
        //         {
        //             _holdTimer = Time.time;
        //         }
        //         else if (_buttonIsPressed.rightIsPressed & _buttonIsPressed.leftIsPressed)
        //         {
        //             if (_holdTimer + _delay < Time.time)
        //             {
        //                 SpawnBigCubeMid();
        //                 _holdTimer = Time.time;
        //             }
        //         }
        //     }
        //     else if(_scoreRead.score == 3 & _spawnCount.spawnCount == 3)
        //     {
        //         tutorialSplitText.SetActive(false);
        //         if(_holdTimer + _delayTwo < Time.time)
        //         {
        //             PlayerPrefs.SetInt("TutorialToggle", 0);
        //         }
        //     }
        // }

        private void LoadDifficultyConfigurations()
        {
            if (PlayerPrefs.GetInt("DifficultyOption", 0) == 0)
            {
                _speed = speedEasy;
                addSpeed = speedAddEasy;
                _addTime = addTimeEasy;
                _pause = pauseEasy;
            }
            else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 1)
            {
                _speed = speedNormal;
                addSpeed = speedAddNormal;
                _addTime = addTimeNormal;
                _pause = pauseNormal;
            }
            else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 2)
            {
                _speed = speedHard;
                addSpeed = speedAddHard;
                _addTime = addTimeHard;
                _pause = pauseHard;
            }
        }

        private void LoadTrailConfiguration()
        {
            if (PlayerPrefs.GetInt("TrailToggle", 0) == 0)
                EnableTrail(true);
            else if (PlayerPrefs.GetInt("TrailToggle", 0) == 1) EnableTrail(false);
        }

        private void EnableTrail(bool isActive)
        {
            leftTrail.SetActive(isActive);
            rightTrail.SetActive(isActive);
        }

        private void SpawnRandomEnemy()
        {
            switch (Random.Range(0, 8))
            {
                case 1:
                    SpawnCubeMid();
                    break;
                case 2:
                    SpawnCubeRight();
                    break;
                case 3:
                    SpawnCubeLeft();
                    break;
                case 4:
                    SpawnCubeTwo();
                    break;
                case 5:
                    SpawnBigCubeRight();
                    break;
                case 6:
                    SpawnBigCubeLeft();
                    break;
                case 7:
                    SpawnBigCubeMid();
                    break;
            }
        }

        private bool IsSpawnCyclePause()
        {
            return _pauseTimer < Time.time;
        }

        private static bool IsTutorialEnabled()
        {
            return PlayerPrefs.GetInt("TutorialToggle", 0) == 1;
        }

        private bool IsLose()
        {
            return _leftFreeze.lost | _rightFreeze.lost;
        }
    }
}