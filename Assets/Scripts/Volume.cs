using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    static public float volume = 0;
    static private bool isSetVolume = false;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Slider _volumeSlider;

    private void Start()
    {
        if(isSetVolume)
        {
            _volumeSlider.value = volume;
        }
        isSetVolume = true;
    }

    void Update()
    {
        if (_volumeSlider != null) volume = _volumeSlider.value;
        if (_audio != null) _audio.volume = volume;
    }
}
