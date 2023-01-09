using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    static public float volume = 0;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Slider _volumeSlider;


    void Update()
    {
        if(_volumeSlider != null) volume = _volumeSlider.value;
        _audio.volume = volume;
    }
}
