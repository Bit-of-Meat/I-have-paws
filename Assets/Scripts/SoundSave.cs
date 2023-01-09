using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSave : MonoBehaviour
{
    public GameObject BGMusic;  //��� ������ � ������� �������
    private AudioSource audioSrc;
    public static float musicVolume;
    public GameObject[] objs1;

    void Awake()
    {
        objs1 = GameObject.FindGameObjectsWithTag("Sound"); //�� �������� ������ ��� Sound ��� ������� � �������
        if (objs1.Length == 0)
        {
            BGMusic = Instantiate(BGMusic); //������� ������ �� �������
            BGMusic.name = "BGMusic";  //�������������, ������ ������� ��� ��������:)
            DontDestroyOnLoad(BGMusic.gameObject); //����� �� ��� ������
        }
        else
        {
            BGMusic = GameObject.Find("BGMusic"); //���������� � �������, ���� �� ��� ����������.
        }
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            Destroy(objs1[0]);
        }
        if(Volume.volume == 0)
        {
            Volume.volume = 0.5f;
        }
        musicVolume = Volume.volume;
    }
    void Start()
    {
        audioSrc = BGMusic.GetComponent<AudioSource>();
    }


    void Update()
    {
        audioSrc.volume = musicVolume;  //������������� ��������� ��� ��������� ��������
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("MusicVol", vol); //��������� ���������
    }
}
