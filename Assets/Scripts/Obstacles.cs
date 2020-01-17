using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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

    SpawnCountAdd spawnCount;
    ScoreAdd scoreRead;
    Loss leftFreeze;
    Loss rightFreeze;
    ControlLeft buttonIsPressed;

    private int rndm;
    public int difficulty;

    private float Timer;
    private float speed;
    private float addTime;
    private float offset = 6.6f;
    private float pauseTimer;
    private float pause = 2.5f;

    private bool stop = false;

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
    private bool tutorialchosen = false;
    public GameObject tutorialRightText;
    public GameObject tutorialLeftText;
    public GameObject tutorialSplitText;
    public GameObject tutorialLostPanel;
    public GameObject tutorialLostPanelEasy;
    private float holdTimer;
    private float delay = 2f;
    private float delayTwo = 3.5f;





    public void SpawnCubeMid()                  //kui tuleb märguanne et see vastane on valitud siis...
    {
        Rigidbody clone = Instantiate(Cube, transform.position, Cube.transform.rotation) as Rigidbody;  //loob kuubiku
        clone.velocity = transform.up * speed;                                                          //annab kiiruse kuubikule
        Timer = Time.time + addTime;                                                                    //alustab uuesti lugemise millal uus vastane märguande saab
        rndm = 10;                                                                                      //ei lase kohe uut vastast valida vaid peab ootama timeri lõppu
    }                                                                                                   //kõik alumised, mille nimi algab "Spawn" on täpselt samad aga erineva kuubiga

    public void SpawnBigCubeMid()
    {
        Rigidbody clone = Instantiate(bigMiddleCube, transform.position, Cube.transform.rotation) as Rigidbody;
        clone.velocity = transform.up * speed;
        Timer = Time.time + addTime;
        rndm = 10;
    }

    public void SpawnCubeLeft()
    {
        Rigidbody clone = Instantiate(Cube, new Vector3(transform.position.x - offset, transform.position.y), Cube.transform.rotation) as Rigidbody;
        clone.velocity = transform.up * speed;
        Timer = Time.time + addTime;
        rndm = 10;
    }

    public void SpawnCubeRight()
    {
        Rigidbody clone = Instantiate(Cube, new Vector3(transform.position.x + offset, transform.position.y), Cube.transform.rotation) as Rigidbody;
        clone.velocity = transform.up * speed;
        Timer = Time.time + addTime;
        rndm = 10;
    }

    public void SpawnBigCubeRight()
    {
        Rigidbody clone = Instantiate(bigCube, new Vector3(transform.position.x + offset, transform.position.y), Cube.transform.rotation) as Rigidbody;
        clone.velocity = transform.up * speed;
        Timer = Time.time + addTime;
        rndm = 10;
    }

    public void SpawnBigCubeLeft()
    {
        Rigidbody clone = Instantiate(bigCube, new Vector3(transform.position.x - offset, transform.position.y), Cube.transform.rotation) as Rigidbody;
        clone.velocity = transform.up * speed;
        Timer = Time.time + addTime;
        rndm = 10;
    }

    public void SpawnCubeTwo()
    {
        Rigidbody clone = Instantiate(twoCube, transform.position, transform.rotation) as Rigidbody;
        clone.velocity = transform.up * speed;
        Timer = Time.time + addTime;
        rndm = 10;
    }

    public void Retry()                             //kui vajutatud "Retry" nupp siis...
    {
        SceneManager.LoadScene(1);                                                  //laeb uuesti selle "stseeni", ehk kõik restardib
        PlayerPrefs.SetInt("TotalTries", PlayerPrefs.GetInt("TotalTries", 0) + 1);  //ja lisab "tries" ühe juurde
    }

    public void Tutorial()
    {
        if(leftFreeze.lost | rightFreeze.lost)
        {
            tutorialRightText.SetActive(false);
            tutorialLeftText.SetActive(false);
            tutorialSplitText.SetActive(false);

            if (holdTimer + delayTwo < Time.time & tutorialchosen)
            {
                SceneManager.LoadScene(1);
            }
            else if(PlayerPrefs.GetInt("DifficultyOption", 0) == 0 & !tutorialchosen)
            {
                tutorialLostPanelEasy.SetActive(true);
                holdTimer = Time.time;
                tutorialchosen = true;
            }
            else if(PlayerPrefs.GetInt("DifficultyOption", 0) != 0 & !tutorialchosen)
            {
                tutorialLostPanel.SetActive(true);
                PlayerPrefs.SetInt("DifficultyOption", 0);
                holdTimer = Time.time;
                tutorialchosen = true;
            }
        }
        else if (spawnCount.spawnCount == 0)
        {
            tutorialRightText.SetActive(true);
            if (!buttonIsPressed.rightIsPressed)
            {
                holdTimer = Time.time;
            }
            else if (buttonIsPressed.rightIsPressed)
            {
                if (holdTimer + delay < Time.time)
                {
                    SpawnBigCubeLeft();
                }
            }
        }
        else if (scoreRead.score == 1 & spawnCount.spawnCount == 1)
        {
            tutorialRightText.SetActive(false);
            tutorialLeftText.SetActive(true);
            if (!buttonIsPressed.leftIsPressed)
            {
                holdTimer = Time.time;
            }
            else if (buttonIsPressed.leftIsPressed)
            {
                if (holdTimer + delay < Time.time)
                {
                    SpawnBigCubeRight();
                    holdTimer = Time.time;
                }
            }
        }
        else if (scoreRead.score == 2 & spawnCount.spawnCount == 2)
        {
            tutorialLeftText.SetActive(false);
            tutorialSplitText.SetActive(true);
            if (!buttonIsPressed.rightIsPressed | !buttonIsPressed.leftIsPressed)
            {
                holdTimer = Time.time;
            }
            else if (buttonIsPressed.rightIsPressed & buttonIsPressed.leftIsPressed)
            {
                if (holdTimer + delay < Time.time)
                {
                    SpawnBigCubeMid();
                    holdTimer = Time.time;
                }
            }
        }
        else if(scoreRead.score == 3 & spawnCount.spawnCount == 3)
        {
            tutorialSplitText.SetActive(false);
            if(holdTimer + delayTwo < Time.time)
            {
                PlayerPrefs.SetInt("TutorialToggle", 0);
            }
        }
    }

    public void DifficultyReader()
    {
        if (PlayerPrefs.GetInt("DifficultyOption", 0) == 0)
        {
            speed = speedEasy;
            addSpeed = speedAddEasy;
            addTime = addTimeEasy;
            pause = pauseEasy;
        }
        else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 1)
        {
            speed = speedNormal;
            addSpeed = speedAddNormal;
            addTime = addTimeNormal;
            pause = pauseNormal;
        }
        else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 2)
        {
            speed = speedHard;
            addSpeed = speedAddHard;
            addTime = addTimeHard;
            pause = pauseHard;
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
        Timer = Time.time;
        //addTime = 1.25f;     //1.7
        //speed = -15f;                                           //nt1: vastaste algne kiirus
        timeAdd = 0.10f;                                        //nt2: vastaste "sündimis" kiirus, mida kiirem seda tihedamalt vastaseid tuleb}
                                                                //addSpeed = 4f;      //

        scoreRead = scoreAdder.GetComponent<ScoreAdd>();
        spawnCount = scoreCounter.GetComponent<SpawnCountAdd>();    //tänu sellele saab teistest scriptidest arve kätte{
        leftFreeze = left.GetComponent<Loss>();                     //nt: saab kätte kas mäng on kaotatud, mis määratakse "ControlLeft" ja "ControlRight" scriptis}
        rightFreeze = right.GetComponent<Loss>();
        buttonIsPressed = left.GetComponent<ControlLeft>();
        
        DifficultyReader();
        TrailReader();
    }

    public void Update()
    {
        if(PlayerPrefs.GetInt("TutorialToggle", 0) == 0)
        {
            if (leftFreeze.lost | rightFreeze.lost)     //kui vastane puudutab Right või Left cube'i siis...
            {
                endPanel.SetActive(true);               //toob ette "Retry" nupu
                pauseButton.SetActive(false);           //peidab pausi nupu
                return;
            }
            else if (pauseTimer < Time.time)
            {
                if (!stop)                              //kui skoor on 10 jaguv arv, ehk iga 10 skoori tagant(nt:20,30,40 jne.)...
                {
                    addTime -= timeAdd;                         //...kiirendab vastaste ilmumist
                    speed -= addSpeed;                          //annab vastastele kiirust juurde
                    stop = true;                                //ja annab märku, et kaks ülemist asja on tehtud, et need ei jääks ainult suurenema
                }
                else if (Timer < Time.time)             //kui timer on 0 jõudnud siis...
                {
                    rndm = Random.Range(0, 8);                  //valib uue vastase suvaliselt
                    if (rndm == 1)                  //väike keskmine kuup(kui valitud 1 või 8 siis loob väikese keskel oleva kuubi)
                    {
                        SpawnCubeMid();
                    }
                    else if (rndm == 2)                         //väike parem kuup(kui valitud 2 siis oob väikese paremal oleva kuubi jne.)
                    {
                        SpawnCubeRight();
                    }
                    else if (rndm == 3)                         //väike vasak kuup
                    {
                        SpawnCubeLeft();
                    }
                    else if (rndm == 4)                         //väikesed vasakul ja paremal kuubid
                    {
                        SpawnCubeTwo();
                    }
                    else if (rndm == 5)                         //Suur parem kuup
                    {
                        SpawnBigCubeRight();
                    }
                    else if (rndm == 6)                         //Suur vasak kuup
                    {
                        SpawnBigCubeLeft();
                    }
                    else if (rndm == 7)                         //Suur keskmine kuup
                    {
                        SpawnBigCubeMid();
                    }
                }
                if (spawnCount.spawnCount == 10)        //kui 10 vastast on sündinud siis..
                {
                    pauseTimer = Time.time + pause;         //lisab timerile, mis teeb pausi, aega(2.5s)
                    spawnCount.spawnCount = 0;              //resetib timeri
                    stop = false;                           //keelab uute vastaste loomise
                }
            }
        }
        else
        {
            Tutorial();
        }
    }
}