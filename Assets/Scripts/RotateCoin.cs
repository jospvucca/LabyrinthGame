using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float _speed;
    public enum WhichWayToRotate
    {
        AroundX,
        AroundY,
        AroundZ
    }
    public WhichWayToRotate _wayToRotate = WhichWayToRotate.AroundX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(_wayToRotate)
            {
            case WhichWayToRotate.AroundX:
                transform.Rotate(Vector3.right * _speed * Time.deltaTime);
                break;

            case WhichWayToRotate.AroundY:
                transform.Rotate(Vector3.up * _speed * Time.deltaTime);
                break;

            case WhichWayToRotate.AroundZ:
                transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
                break;
            }
    }
}
