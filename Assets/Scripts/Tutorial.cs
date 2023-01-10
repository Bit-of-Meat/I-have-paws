using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Tutorial : MonoBehaviour
{
    public float vignette_speed = 2f;
    private PostProcessVolume _PostProcessVolume;
    private Vignette _Vignette;
    private float t = 0f;
    public GameObject tutorial;
    private bool Completed = false;

    void Start()
    {
        _PostProcessVolume = GetComponent<PostProcessVolume>();
        _PostProcessVolume.profile.TryGetSettings(out _Vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Completed = true;
            _PostProcessVolume = GetComponent<PostProcessVolume>();
            _Vignette.intensity.value = Mathf.Lerp(_Vignette.intensity.value, 0.1f, t);
            t += Time.deltaTime / vignette_speed;
            Destroy(tutorial);
        }
        if (_Vignette.intensity.value != 0.326 && Completed == false)
        {
        t += Time.deltaTime / vignette_speed;
        _Vignette.intensity.value = Mathf.Lerp(_Vignette.intensity.value, 0.4f, t);
        }
    }
}
