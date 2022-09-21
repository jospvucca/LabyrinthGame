using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public int _countdownTime;
    GameObject _gameManager;
    Text _countdownText;

    // Start is called before the first frame update
    void Start()
    {
        if(_gameManager == null)
        {
            _gameManager = GameObject.FindGameObjectWithTag("GameController");
        }
        _countdownText = GetComponent<Text>();
        StartCoroutine(CountDownToStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountDownToStart()
    {
        while (_countdownTime > 0) 
        {
            _countdownText.text = _countdownTime.ToString();
            yield return new WaitForSeconds(1);
            _countdownTime--;
        }
        _countdownText.text = "GO!";
        yield return new WaitForSeconds(1);
        _gameManager.GetComponent<GameManager>().BeginGame();
        this.gameObject.SetActive(false);
    }
}
