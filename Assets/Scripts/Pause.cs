using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseObject;
    private bool _paused;
    private bool Paused
    {
        get { return _paused; }
        set
        {
            _paused = value;
            _pauseObject.SetActive(_paused);

            if(_paused) Time.timeScale = 0;
            if (!_paused) Time.timeScale = 1;
        }
    }

    private void Start()
    {
        Paused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Paused = !Paused;
    }
}
