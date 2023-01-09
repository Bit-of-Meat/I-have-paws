using System.Collections;
using UnityEngine;

public class LetTime : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _start;
    [SerializeField] private int _timeStart;
    [SerializeField] private int _timeEnd;

    void Start()
    {
        if(_start) _animator.SetBool("Show", true);
        StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        while (true)
        {
            if (!_start)
                yield return new WaitForSeconds(_timeStart);
            else
            {
                _start = false;
                _animator.SetBool("Show", false);
            }
            _animator.SetBool("Show", true);
            yield return new WaitForSeconds(_timeEnd);
            _animator.SetBool("Show", false);
        }
    }
}
