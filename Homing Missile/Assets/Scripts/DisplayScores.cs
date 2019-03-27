using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class DisplayScores : MonoBehaviour
{

    public TextMeshProUGUI _name1, _name2, _name3, _name4, _name5;
    public TextMeshProUGUI _score1, _score2, _score3, _score4, _score5;
    public string userInit;
    public TextMeshProUGUI _player;
    public GameObject playerInput;
    public GameObject _scorePanel;
    public bool proceed = false;


    // Start is called before the first frame update
    void Start()
    {
        playerInput.gameObject.SetActive(true);
        
    }

    public void Update()
    {
        if(proceed && !_scorePanel.gameObject.activeInHierarchy)
        {
            DisplayScorePanel();
            playerInput.gameObject.SetActive(false);
            _scorePanel.gameObject.SetActive(true);
        }
    }

    public void DisplayScorePanel()
    {
        _name1.text = GameManager.manager.HighScores[0].playerInitials;
        _name2.text = GameManager.manager.HighScores[1].playerInitials;
        _name3.text = GameManager.manager.HighScores[2].playerInitials;
        _name4.text = GameManager.manager.HighScores[3].playerInitials;
        _name5.text = GameManager.manager.HighScores[4].playerInitials;

        _score1.text = GameManager.manager.HighScores[0].scoreMinutes.ToString("00") + ":"
             + GameManager.manager.HighScores[0].scoreSeconds.ToString("00");
        _score2.text = GameManager.manager.HighScores[1].scoreMinutes.ToString("00") + ":"
        + GameManager.manager.HighScores[1].scoreSeconds.ToString("00");
        _score3.text = GameManager.manager.HighScores[2].scoreMinutes.ToString("00") + ":"
            + GameManager.manager.HighScores[2].scoreSeconds.ToString("00");
        _score4.text = GameManager.manager.HighScores[3].scoreMinutes.ToString("00") + ":"
            + GameManager.manager.HighScores[3].scoreSeconds.ToString("00");
        _score5.text = GameManager.manager.HighScores[4].scoreMinutes.ToString("00") + ":"
            + GameManager.manager.HighScores[4].scoreSeconds.ToString("00");
    }

    public void sortScores()
    {
        GameManager.manager.HighScores.Sort(delegate (Scores x, Scores y)
        {
            //return string.Compare(x.totalTime.ToString(), y.totalTime.ToString());
            return x.totalTime.CompareTo(y.totalTime);
        });
        GameManager.manager.HighScores.Reverse();
        }
    
    public void setPlayerInit()
    {
        userInit = _player.text;
        GameManager.manager.AddScore(userInit, GameManager.manager.playerMin, GameManager.manager.playerSec, GameManager.manager.totalTime);
        sortScores();
        GameManager.manager.SaveScores();
        proceed = true;
    }
}
