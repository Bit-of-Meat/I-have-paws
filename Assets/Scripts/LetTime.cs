using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LetTime : MonoBehaviour
{
    public TMP_Text clockText;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _start;
    [SerializeField] private float _timeStart;
    public float Timer0;
    [SerializeField] private short _timeEnd;

    void Start()
    {
        Timer0 = _timeStart;
        clockText.text = _timeStart.ToString();
        if (_start) _animator.SetBool("Show", true);
        StartCoroutine(Tick());
    }
    void Update()
    {
        if (!_start && _timeStart != 0)
        {
            _timeStart -= Time.deltaTime;
            clockText.text = (_timeStart).ToString("0");
        }
    }

    IEnumerator Tick()
    {
        while (true)
        {
            if (!_start)
            {
                yield return new WaitForSeconds(_timeStart);
            }
            else
            {
                _start = false;
                _animator.SetBool("Show", false);
            }
            _animator.SetBool("Show", true);
            yield return new WaitForSeconds(_timeEnd);
            _timeStart = Timer0;
            _animator.SetBool("Show", false);
        }
    }
}
