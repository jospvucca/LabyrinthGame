using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int _value;
    GameObject _gameManager;
    // Start is called before the first frame update
    void Start()
    {
       if(_gameManager == null)
        {
            _gameManager = GameObject.FindGameObjectWithTag("GameController");
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        _gameManager.GetComponent<GameManager>().Collect(_value);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
