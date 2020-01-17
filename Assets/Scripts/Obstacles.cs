using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    public GameObject scoreCounter;
    public GameObject scoreAdder;

    public GameObject left;
    public GameObject leftTrail;
    public GameObject right;
    public GameObject rightTrail;

    public GameObject endPanel;
    public GameObject pauseButton;

    public Rigidbody Cube;
    public Rigidbody bigCube;
    public Rigidbody twoCube;
    public Rigidbody bigMiddleCube;

    private SpawnCountAdd _spawnCount;
    private ScoreAdd _scoreRead;
    private Loss _leftFreeze;
    private Loss _rightFreeze;
    private ControlLeft _buttonIsPressed;

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

    //Difficulty
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

    //Tutorial
    private bool _isTutorial = false;
    public GameObject tutorialRightText;
    public GameObject tutorialLeftText;
    public GameObject tutorialSplitText;
    public GameObject tutorialLostPanel;
    public GameObject tutorialLostPanelEasy;
    private float _holdTimer;
    private float _delay = 2f;
    private float _delayTwo = 3.5f;





    public void SpawnCubeMid()                  //kui tuleb märguanne et see vastane on valitud siis...
    {
        Rigidbody clone = Instantiate(Cube, transform.position, Cube.transform.rotation) as Rigidbody;  //loob kuubiku
        clone.velocity = transform.up * _speed;                                                          //annab kiiruse kuubikule
        _timer = Time.time + _addTime;                                                                    //alustab uuesti lugemise millal uus vastane märguande saab
        _rand = 10;                                                                                      //ei lase kohe uut vastast valida vaid peab ootama timeri lõppu
    }                                                                                                   //kõik alumised, mille nimi algab "Spawn" on täpselt samad aga erineva kuubiga

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

    public void Retry()                             //kui vajutatud "Retry" nupp siis...
    {
        SceneManager.LoadScene(1);                                                  //laeb uuesti selle "stseeni", ehk kõik restardib
        PlayerPrefs.SetInt("TotalTries", PlayerPrefs.GetInt("TotalTries", 0) + 1);  //ja lisab "tries" ühe juurde
    }

    public void Tutorial()
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
    }

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
        if (PlayerPrefs.GetInt("TrailToggle", 0) == 0)           //kui enne oli "saba valik" tõene siis...{
        {
            leftTrail.SetActive(true);                              //paneb "saba" käima
            rightTrail.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("TrailToggle", 0) == 1)
        {
            leftTrail.SetActive(false);                             //võtab "saba" ära}
            rightTrail.SetActive(false);
        }
    }

    public void Start()                                     //enne mängu algust määrab osadele muutujatele arvud{
    {
        _timer = Time.time;
        //addTime = 1.25f;     //1.7
        //speed = -15f;                                           //nt1: vastaste algne kiirus
        timeAdd = 0.10f;                                        //nt2: vastaste "sündimis" kiirus, mida kiirem seda tihedamalt vastaseid tuleb}
                                                                //addSpeed = 4f;      //

        _scoreRead = scoreAdder.GetComponent<ScoreAdd>();
        _spawnCount = scoreCounter.GetComponent<SpawnCountAdd>();    //tänu sellele saab teistest scriptidest arve kätte{
        _leftFreeze = left.GetComponent<Loss>();                     //nt: saab kätte kas mäng on kaotatud, mis määratakse "ControlLeft" ja "ControlRight" scriptis}
        _rightFreeze = right.GetComponent<Loss>();
        _buttonIsPressed = left.GetComponent<ControlLeft>();
        
        DifficultyReader();
        TrailReader();
    }

    public void Update()
    {
        if(PlayerPrefs.GetInt("TutorialToggle", 0) == 0)
        {
            if (_leftFreeze.lost | _rightFreeze.lost)     //kui vastane puudutab Right või Left cube'i siis...
            {
                endPanel.SetActive(true);               //toob ette "Retry" nupu
                pauseButton.SetActive(false);           //peidab pausi nupu
                return;
            }
            else if (_pauseTimer < Time.time)
            {
                if (!_stop)                              //kui skoor on 10 jaguv arv, ehk iga 10 skoori tagant(nt:20,30,40 jne.)...
                {
                    _addTime -= timeAdd;                         //...kiirendab vastaste ilmumist
                    _speed -= addSpeed;                          //annab vastastele kiirust juurde
                    _stop = true;                                //ja annab märku, et kaks ülemist asja on tehtud, et need ei jääks ainult suurenema
                }
                else if (_timer < Time.time)             //kui timer on 0 jõudnud siis...
                {
                    _rand = Random.Range(0, 8);                  //valib uue vastase suvaliselt
                    if (_rand == 1)                  //väike keskmine kuup(kui valitud 1 või 8 siis loob väikese keskel oleva kuubi)
                    {
                        SpawnCubeMid();
                    }
                    else if (_rand == 2)                         //väike parem kuup(kui valitud 2 siis oob väikese paremal oleva kuubi jne.)
                    {
                        SpawnCubeRight();
                    }
                    else if (_rand == 3)                         //väike vasak kuup
                    {
                        SpawnCubeLeft();
                    }
                    else if (_rand == 4)                         //väikesed vasakul ja paremal kuubid
                    {
                        SpawnCubeTwo();
                    }
                    else if (_rand == 5)                         //Suur parem kuup
                    {
                        SpawnBigCubeRight();
                    }
                    else if (_rand == 6)                         //Suur vasak kuup
                    {
                        SpawnBigCubeLeft();
                    }
                    else if (_rand == 7)                         //Suur keskmine kuup
                    {
                        SpawnBigCubeMid();
                    }
                }
                if (_spawnCount.spawnCount == 10)        //kui 10 vastast on sündinud siis..
                {
                    _pauseTimer = Time.time + _pause;         //lisab timerile, mis teeb pausi, aega(2.5s)
                    _spawnCount.spawnCount = 0;              //resetib timeri
                    _stop = false;                           //keelab uute vastaste loomise
                }
            }
        }
        else
        {
            Tutorial();
        }
    }
}