using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    public float _delay;
    Animation _anim;
    public string _animName;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animation>();
        if(_animName == null)
        {
            _animName = "moveSpike";
        }
        StartCoroutine(Go(_animName));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Go(string animName)
    {
        while(true)
        {
            _anim.Play(animName);
            yield return new WaitForSeconds(_delay);
        }
    }
}
