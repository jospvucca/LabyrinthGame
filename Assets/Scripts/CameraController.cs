using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject _target;
    Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.position = _offset + _target.transform.position;
    }
}
