using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _timeStart = 5;
    [SerializeField] private int _timeEnd = 3;
    [SerializeField] private List<Animator> _animatorsRoots;
    [SerializeField] private string _tagRoot = "Root";
    private bool _isUpRoots = false;
    private int _nowTime;
    private GameObject[] _roots;
    private bool IsUpRoots { 
        get
        {
            return _isUpRoots;
        }
        set
        {
            foreach (var animator in _animatorsRoots)
                animator.SetBool("Show", value);

            _isUpRoots = value;
        } 
    }
    

    private void Start()
    {
        _nowTime = _timeStart;
        _roots = GameObject.FindGameObjectsWithTag(_tagRoot);
        foreach(GameObject root in _roots)
        {
            _animatorsRoots.Add(root.GetComponent<Animator>());
        }
        StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        while (true)
        {
            _nowTime--;

            if (_nowTime == 0 && !IsUpRoots) 
            { 
                IsUpRoots = true;
                _nowTime = _timeEnd;
            }
            if (_nowTime == 0 && IsUpRoots)
            {
                IsUpRoots = false;
                _nowTime = _timeStart;
            }
            _text.text = _nowTime.ToString();

            yield return new WaitForSeconds(1);
        }
    }
}
