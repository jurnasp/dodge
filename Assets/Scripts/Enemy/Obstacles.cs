using UnityEngine;

namespace Dodge.Enemy
{
    public class Obstacles : MonoBehaviour
    {
        /*
            public GameObject scoreCounter;
            public GameObject scoreAdder;
        
            public GameObject left;
            public GameObject leftTrail;
            public GameObject right;
            public GameObject rightTrail;
        
            public GameObject endPanel;
            public GameObject pauseButton;
        
            [SerializeField]
            public List<Rigidbody> obstacleList;
            
            public Rigidbody Cube;
            public Rigidbody bigCube;
            public Rigidbody twoCube;
            public Rigidbody bigMiddleCube;
        
            private SpawnCountAdd _spawnCount;
            private ScoreAdd _scoreRead;
            private Loss _leftFreeze;
            private Loss _rightFreeze;
        
            private int _rand;
            public int difficulty;
        
            private float _timer;
            private float _speed;
            private float _addTime;
            private float _offset = 6.6f;
            private float _pauseTimer;
            private float _pause = 2.5f;
        
            private bool _stop;
        
            public float addSpeed;
            public float timeAdd;
        
            
            private float speedEasy = -8f;
            private float speedNormal = -12f;
            private float speedHard = -15f;
        
            private float speedAddEasy = 3f;
            private float speedAddNormal = 3.5f;
            private float speedAddHard = 4f;
        
            private float addTimeEasy = 1.75f;
            private float addTimeNormal = 1.5f;
            private float addTimeHard = 1.25f;
            
            private float pauseEasy = 3.5f;
            private float pauseNormal = 2f;
            private float pauseHard = 2.5f;
        
            
            private bool _isTutorial = false;
            public GameObject tutorialRightText;
            public GameObject tutorialLeftText;
            public GameObject tutorialSplitText;
            public GameObject tutorialLostPanel;
            public GameObject tutorialLostPanelEasy;
            private float _holdTimer;
            private float _delay = 2f;
            private float _delayTwo = 3.5f;
        
        
        
        
        
            public void SpawnCubeMid()                  
            {
                Rigidbody clone = Instantiate(Cube, transform.position, Cube.transform.rotation) as Rigidbody;  
                clone.velocity = transform.up * _speed;                                                          
                _timer = Time.time + _addTime;                                                                    
                _rand = 10;                                                                                      
            }                                                                                                   
        
            public void SpawnBigCubeMid()
            {
                Rigidbody clone = Instantiate(bigMiddleCube, transform.position, Cube.transform.rotation) as Rigidbody;
                clone.velocity = transform.up * _speed;
                _timer = Time.time + _addTime;
                _rand = 10;
            }
        
            public void SpawnCubeLeft()
            {
                Rigidbody clone = Instantiate(Cube, new Vector3(transform.position.x - _offset, transform.position.y), Cube.transform.rotation) as Rigidbody;
                clone.velocity = transform.up * _speed;
                _timer = Time.time + _addTime;
                _rand = 10;
            }
        
            public void SpawnCubeRight()
            {
                Rigidbody clone = Instantiate(Cube, new Vector3(transform.position.x + _offset, transform.position.y), Cube.transform.rotation) as Rigidbody;
                clone.velocity = transform.up * _speed;
                _timer = Time.time + _addTime;
                _rand = 10;
            }
        
            public void SpawnBigCubeRight()
            {
                Rigidbody clone = Instantiate(bigCube, new Vector3(transform.position.x + _offset, transform.position.y), Cube.transform.rotation) as Rigidbody;
                clone.velocity = transform.up * _speed;
                _timer = Time.time + _addTime;
                _rand = 10;
            }
        
            public void SpawnBigCubeLeft()
            {
                Rigidbody clone = Instantiate(bigCube, new Vector3(transform.position.x - _offset, transform.position.y), Cube.transform.rotation) as Rigidbody;
                clone.velocity = transform.up * _speed;
                _timer = Time.time + _addTime;
                _rand = 10;
            }
        
            public void SpawnCubeTwo()
            {
                Rigidbody clone = Instantiate(twoCube, transform.position, transform.rotation) as Rigidbody;
                clone.velocity = transform.up * _speed;
                _timer = Time.time + _addTime;
                _rand = 10;
            }
        
            public void Retry()                             
            {
                SceneManager.LoadScene(1);                                                  
                PlayerPrefs.SetInt("TotalTries", PlayerPrefs.GetInt("TotalTries", 0) + 1);  
            }
        
            /*public void Tutorial()
            {
                if(_leftFreeze.lost | _rightFreeze.lost)
                {
                    tutorialRightText.SetActive(false);
                    tutorialLeftText.SetActive(false);
                    tutorialSplitText.SetActive(false);
        
                    if (_holdTimer + _delayTwo < Time.time & _isTutorial)
                    {
                        SceneManager.LoadScene(1);
                    }
                    else if(PlayerPrefs.GetInt("DifficultyOption", 0) == 0 & !_isTutorial)
                    {
                        tutorialLostPanelEasy.SetActive(true);
                        _holdTimer = Time.time;
                        _isTutorial = true;
                    }
                    else if(PlayerPrefs.GetInt("DifficultyOption", 0) != 0 & !_isTutorial)
                    {
                        tutorialLostPanel.SetActive(true);
                        PlayerPrefs.SetInt("DifficultyOption", 0);
                        _holdTimer = Time.time;
                        _isTutorial = true;
                    }
                }
                else if (_spawnCount.spawnCount == 0)
                {
                    tutorialRightText.SetActive(true);
                    if (!_buttonIsPressed.rightIsPressed)
                    {
                        _holdTimer = Time.time;
                    }
                    else if (_buttonIsPressed.rightIsPressed)
                    {
                        if (_holdTimer + _delay < Time.time)
                        {
                            SpawnBigCubeLeft();
                        }
                    }
                }
                else if (_scoreRead.score == 1 & _spawnCount.spawnCount == 1)
                {
                    tutorialRightText.SetActive(false);
                    tutorialLeftText.SetActive(true);
                    if (!_buttonIsPressed.leftIsPressed)
                    {
                        _holdTimer = Time.time;
                    }
                    else if (_buttonIsPressed.leftIsPressed)
                    {
                        if (_holdTimer + _delay < Time.time)
                        {
                            SpawnBigCubeRight();
                            _holdTimer = Time.time;
                        }
                    }
                }
                else if (_scoreRead.score == 2 & _spawnCount.spawnCount == 2)
                {
                    tutorialLeftText.SetActive(false);
                    tutorialSplitText.SetActive(true);
                    if (!_buttonIsPressed.rightIsPressed | !_buttonIsPressed.leftIsPressed)
                    {
                        _holdTimer = Time.time;
                    }
                    else if (_buttonIsPressed.rightIsPressed & _buttonIsPressed.leftIsPressed)
                    {
                        if (_holdTimer + _delay < Time.time)
                        {
                            SpawnBigCubeMid();
                            _holdTimer = Time.time;
                        }
                    }
                }
                else if(_scoreRead.score == 3 & _spawnCount.spawnCount == 3)
                {
                    tutorialSplitText.SetActive(false);
                    if(_holdTimer + _delayTwo < Time.time)
                    {
                        PlayerPrefs.SetInt("TutorialToggle", 0);
                    }
                }
            }#1#
        
            public void DifficultyReader()
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
        
            public void TrailReader()
            {
                if (PlayerPrefs.GetInt("TrailToggle", 0) == 0)           
                {
                    leftTrail.SetActive(true);                              
                    rightTrail.SetActive(true);
                }
                else if (PlayerPrefs.GetInt("TrailToggle", 0) == 1)
                {
                    leftTrail.SetActive(false);                             
                    rightTrail.SetActive(false);
                }
            }
        
            public void Start()                                     
            {
                _timer = Time.time;
                
                
                timeAdd = 0.10f;                                        
                                                                        
        
                _scoreRead = scoreAdder.GetComponent<ScoreAdd>();
                _spawnCount = scoreCounter.GetComponent<SpawnCountAdd>();    
                _leftFreeze = left.GetComponent<Loss>();                     
                _rightFreeze = right.GetComponent<Loss>();
                /*_buttonIsPressed = left.GetComponent<ControlLeft>();#1#
                
                DifficultyReader();
                TrailReader();
            }
        
            public void Update()
            {
                if(PlayerPrefs.GetInt("TutorialToggle", 0) == 0)
                {
                    if (_leftFreeze.lost | _rightFreeze.lost)     
                    {
                        endPanel.SetActive(true);               
                        pauseButton.SetActive(false);           
                        return;
                    }
                    else if (_pauseTimer < Time.time)
                    {
                        if (!_stop)                              
                        {
                            _addTime -= timeAdd;                         
                            _speed -= addSpeed;                          
                            _stop = true;                                
                        }
                        else if (_timer < Time.time)             
                        {
                            _rand = Random.Range(0, 8);                  
                            if (_rand == 1)                  
                            {
                                SpawnCubeMid();
                            }
                            else if (_rand == 2)                         
                            {
                                SpawnCubeRight();
                            }
                            else if (_rand == 3)                         
                            {
                                SpawnCubeLeft();
                            }
                            else if (_rand == 4)                         
                            {
                                SpawnCubeTwo();
                            }
                            else if (_rand == 5)                         
                            {
                                SpawnBigCubeRight();
                            }
                            else if (_rand == 6)                         
                            {
                                SpawnBigCubeLeft();
                            }
                            else if (_rand == 7)                         
                            {
                                SpawnBigCubeMid();
                            }
                        }
                        if (_spawnCount.spawnCount == 10)        
                        {
                            _pauseTimer = Time.time + _pause;         
                            _spawnCount.spawnCount = 0;              
                            _stop = false;                           
                        }
                    }
                }
                /*else
                {
                    Tutorial();
                }#1#
            }*/
    }
}