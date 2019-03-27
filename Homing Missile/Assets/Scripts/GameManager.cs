using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class GameManager : MonoBehaviour {

    public static GameManager manager;

    public string playerInit;
    public float playerMin;
    public float playerSec;
    public float totalTime;
    public static int lives = 3;
    public GameObject heart1, heart2, heart3;
    public TextMeshProUGUI gameText;
    public Text timerText;
    public float seconds, minutes;
    public bool isDead = false;
    [SerializeField] public List<Scores> HighScores = new List<Scores>();

    public string myScore;

    private void Awake() //singleton design
    {


        if (!File.Exists(Application.persistentDataPath + "/scores.dat"))
        {
            InitializeScores();
            Debug.Log(Application.persistentDataPath + "/scores.dat created");
        }
    
        LoadScores();
        

        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if(manager !=this)
        {
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start ()
    {
        lives = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        MissileSpawner.canSpawn = true;
        StartCoroutine("blinkText");
        
    }

    // Update is called once per frame
    void Update()
    {
        minutes = (int)(Time.timeSinceLevelLoad / 60f);
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        timerText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");

        switch (lives)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                isDead = true;
                MissileSpawner.canSpawn = false;
                break;
        }

        if(isDead && !SceneManager.GetSceneByName("End").isLoaded)
        {
            StartCoroutine("loadEnd");
        }

    }
  IEnumerator blinkText()
    {
        for(int i =0; i<11; i++)
        {
            yield return new WaitForSeconds(0.5f);
            gameText.enabled = !gameText.enabled;                
        }
    }

    IEnumerator loadEnd()
    {
        myScore = minutes.ToString("00") + ":" + seconds.ToString("00");
        playerMin = minutes;
        playerSec = seconds;
        totalTime = (int)(Time.timeSinceLevelLoad);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("End",LoadSceneMode.Additive);
        StopAllCoroutines();
    }

    public void InitializeScores()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/scores.dat");

        List<Scores> _scores = new List<Scores>();
        _scores.Add(new Scores("SUE", 2f, 0f, 120f));
        _scores.Add(new Scores("BOB",1f,45f, 105f));
        _scores.Add(new Scores("JOE",1f,30f, 90f));
        _scores.Add(new Scores("JAN", 1f, 15f,75f));
        _scores.Add(new Scores("MOE", 1f, 0f,60f));

        bf.Serialize(file, _scores);
        file.Close();
    }


    public void SaveScores()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/scores.dat");

        List<Scores> _scores = new List<Scores>();
        _scores = HighScores;
        bf.Serialize(file, _scores);
        file.Close();
    }

    public void LoadScores()
    {
        if(File.Exists(Application.persistentDataPath+"/scores.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/scores.dat", FileMode.Open);
            List<Scores> _scores = (List<Scores>)bf.Deserialize(file);
            file.Close();

            HighScores = _scores;

         }
    }
    public void AddScore(string _int, float _min, float _sec, float _total)
    {
        Scores score = new Scores(_int, _min, _sec, _total);
        HighScores.Add(score);
    }
    public static int SortByScore(Scores p1, Scores p2)
    {
        return p1.scoreSeconds.CompareTo(p2.scoreSeconds);
    }
}

[Serializable]
public class Scores //: IComparable<Scores>
{
    public string playerInitials;
    public float scoreMinutes;
    public float scoreSeconds;
    public float totalTime;
    public Scores(string _init, float _min, float _sec, float _total)
    {
        playerInitials = _init;
        scoreMinutes = _min;
        scoreSeconds = _sec;
        totalTime = _total;

    }

    
}

[Serializable]
public class ScoreList
{
    public List<Scores> highScores = new List<Scores>();
}
