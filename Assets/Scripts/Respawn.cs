using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public GameObject player;
    public Animator _animatorScren;
    [SerializeField] private Animator anim;
    public bool _goNextScene = false;
    [SerializeField] private int _idNextScene;
    [SerializeField] private float _timeNextScene;
    [SerializeField] private float _timePritech;
    private bool _used = false;
    private Vector2 _posNext = Vector2.zero;

    private void Start()
    {
        _goNextScene = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_used)
        {
            player.SetActive(false);
            StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene()
    {
        _animatorScren.SetTrigger("Hide");
        yield return new WaitForSeconds(_timeNextScene);
        SceneManager.LoadScene(_idNextScene);
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        _used = true;
        _goNextScene = true;
        anim.SetBool("_goNextScene", _goNextScene);
    }
}
