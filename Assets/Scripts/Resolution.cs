using TMPro;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    private void Start()
    {
        _dropdown.value = 2;
    }

    public void Chenges()
    {
        if (_dropdown.value == 0) Screen.SetResolution(800, 400, true);
        if (_dropdown.value == 1) Screen.SetResolution(1366, 768, true);
        if (_dropdown.value == 2) Screen.SetResolution(1920, 1080, true);
        if (_dropdown.value == 3) Screen.SetResolution(2560, 1440, true);
        if (_dropdown.value == 4) Screen.SetResolution(3840, 2160, true);

    }
}
