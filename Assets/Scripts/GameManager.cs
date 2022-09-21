using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int _score;

    public GameObject _player;
    public GameObject _mainCanvas;
    public GameObject _gameOverCanvas;
    public Text _scoreText;
    public Text _timeDisplay;
    public float _startTime;

    public GameObject _youWon;
    public GameObject _youLost;

    enum GameStates
    {
        IsPaused,
        IsPlaying,
        IsOver
    }

    GameStates _gameState = GameStates.IsPaused;


    static int _overallScore;
    static int _currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (_currentLevel == 0)
        {
            _score = 0;
        }
        else
        {
            _score = _overallScore;
        }
        _mainCanvas.SetActive(true);
        _gameOverCanvas.SetActive(false);
        if (_youWon == null)
        {

        }
        else
        {
            _youWon.SetActive(false);
        }
        if(_youLost == null)
        {

        }
        else
        {
            _youLost.SetActive(false);
        }
        if(_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        _timeDisplay.gameObject.SetActive(false);
        _player.GetComponent<PlayerController>().FreezePlayer(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_gameState)
        {
            case GameStates.IsPaused:
                break;
            case GameStates.IsPlaying:
                _startTime -= Time.deltaTime;
                _timeDisplay.text = _startTime.ToString("0.0");
                if (_startTime <= 0)
                {
                    _startTime = 0;
                    _mainCanvas.SetActive(false);
                    _gameOverCanvas.SetActive(true);
                    _player.GetComponent<PlayerController>().FreezePlayer(true);
                }
                break;

            case GameStates.IsOver:
                _timeDisplay.text = null;
                _youWon.SetActive(true);
                _player.GetComponent<PlayerController>().FreezePlayer(true);
                break;
        }
    }

    public void BeginGame()
    {
        _timeDisplay.gameObject.SetActive(true);
        _player.GetComponent<PlayerController>().FreezePlayer(false);
        _gameState = GameStates.IsPlaying;
    }

    public void Collect(int amount)
    {
        _score += amount;
        //anim
        _scoreText.text = _score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && _currentLevel < 2 && _currentLevel != 1)   //i coini
        {
            _currentLevel++;
            _overallScore = _score;
            SceneManager.LoadScene(_currentLevel); 
        }

        if(other.gameObject.tag == "Player" && _currentLevel == 1)
        {
            _overallScore = _score;
            _mainCanvas.SetActive(false);
            _gameOverCanvas.SetActive(true);
            if (_youLost.activeSelf == true)
            {
                _youLost.SetActive(false);
            }

            _gameState = GameStates.IsOver;
        }
    }
}
