using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float _speed;
    public Rigidbody _playerRigidbody;
    public GameObject _explosion;
    bool _isFrozen;


    // Start is called before the first frame update
    void Start()
    {
        if(_playerRigidbody == null)
        {
            _playerRigidbody = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!_isFrozen)
        {
            float _moveHorizontally = Input.GetAxis("Horizontal");
            float _moveVertically = Input.GetAxis("Vertical");

            Vector3 _movement = new Vector3(_moveHorizontally, 0.0f, _moveVertically);

            _playerRigidbody.AddForce(_movement * _speed);
        }

    }

    public void FreezePlayer(bool value)
    {
        _isFrozen = value;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
        Instantiate(_explosion, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
