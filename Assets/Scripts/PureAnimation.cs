using System;
using System.Collections;
using UnityEngine;

public class PureAnimation
{
    public Vector2 LastChanges { get; private set; }
    public Coroutine LastAnimation { get; private set; }

    readonly private MonoBehaviour _context;

    public PureAnimation(MonoBehaviour context)
    {
        _context = context;
    }

    public void Play(float duration, Func<float, Vector2> body)
    {
        if (LastAnimation != null)
            _context.StopCoroutine(LastAnimation);

        LastAnimation = _context.StartCoroutine(GetAnimation(duration, body));
    }

    private IEnumerator GetAnimation(float duration, Func<float, Vector2> body)
    {
        var expiredSeconds = 0f;
        var progress = 0f;

        while(progress < 1f)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / duration;

            LastChanges = body.Invoke(progress);

            yield return null;
        }
    }

}

