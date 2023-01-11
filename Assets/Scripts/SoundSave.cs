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
        if (objs1.Length == 0 && (SceneManager.GetActiveScene().buildIndex != 4 || SceneManager.GetActiveScene().buildIndex != 0))
        {
            BGMusic = Instantiate(BGMusic); //������� ������ �� �������
            BGMusic.name = "BGMusic";  //�������������, ������ ������� ��� ��������:)
            DontDestroyOnLoad(BGMusic.gameObject); //����� �� ��� ������
        }
        else
        {
            BGMusic = GameObject.Find("BGMusic"); //���������� � �������, ���� �� ��� ����������.
        }
        if(SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(objs1[0]);
        }
    }
    void Start()
    {
        audioSrc = BGMusic.GetComponent<AudioSource>();
    }


    void Update()
    {
        if(audioSrc != null) audioSrc.volume = Volume.volume;  //������������� ��������� ��� ��������� ��������
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("MusicVol", vol); //��������� ���������
    }
}
