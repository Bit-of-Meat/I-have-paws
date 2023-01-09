using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSave : MonoBehaviour
{
    public GameObject BGMusic;  //Ваш объект с фоновой музыкой
    private AudioSource audioSrc;
    public static float musicVolume;
    public GameObject[] objs1;

    void Awake()
    {
        objs1 = GameObject.FindGameObjectsWithTag("Sound"); //не забываем задать тег Sound для префаба с музыкой
        if (objs1.Length == 0)
        {
            BGMusic = Instantiate(BGMusic); //создаем объект из префаба
            BGMusic.name = "BGMusic";  //необязательно, просто внешний вид улучшает:)
            DontDestroyOnLoad(BGMusic.gameObject); //Ответ на Ваш вопрос
        }
        else
        {
            BGMusic = GameObject.Find("BGMusic"); //обращаемся к объекту, если он уже существует.
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
        audioSrc.volume = musicVolume;  //устанавливаем громкость при изменении слайдера
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("MusicVol", vol); //сохраняем громкость
    }
}
