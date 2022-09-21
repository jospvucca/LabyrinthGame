using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float _speed;
    public Transform[] _patrolPoints;
    int _currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        _currentPoint = 0;
        transform.position = _patrolPoints[_currentPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == _patrolPoints[_currentPoint].position)
        {
            _currentPoint++;
        }

        if(_currentPoint >= _patrolPoints.Length)
        {
            _currentPoint = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, _patrolPoints[_currentPoint].position, _speed * Time.deltaTime);

    }
}
