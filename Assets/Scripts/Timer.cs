using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _time = 15;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Tick());
    }

    IEnumerator Tick()
    {
        _time--;
        _text.text = $"0:{_time}";

        yield return new WaitForSeconds(1);
    }
}
