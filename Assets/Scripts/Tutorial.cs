using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private float vignette_speed = 2f;
    [SerializeField] private PostProcessVolume _PostProcessVolume;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private Slingshot _slingshot;
    private Vignette _Vignette;
    private float _intensity = 0;
    private bool Completed = false;

    void Start()
    {
        _PostProcessVolume.profile.TryGetSettings(out _Vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if (_slingshot.IsMouseDown)
        {
            Completed = true;
            _intensity = 0.2f;
            Destroy(tutorial);
        }
        if (Completed == false)
        {
            _intensity = 0.4f;
        }
        _Vignette.intensity.value = Mathf.Lerp(_Vignette.intensity.value, _intensity, vignette_speed * Time.deltaTime);
        
    }
}
