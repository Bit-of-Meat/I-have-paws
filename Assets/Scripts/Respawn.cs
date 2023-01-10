using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer _spriteRendererPlayer;
    [SerializeField] private Animator _animatorScren;
    [SerializeField] private Animator anim;
    [SerializeField] private bool _goNextScene = false;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int _idNextScene;
    [SerializeField] private float _timeStartAnimationNextScene;
    [SerializeField] private float _timeNextScene;
    [SerializeField] private float _timePritech;
    private bool _used = false;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _goNextScene = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_used)
        {
            _spriteRenderer.flipX = _spriteRendererPlayer.flipX;
            player.SetActive(false);
            StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(_timeStartAnimationNextScene);
        
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

    public void Effect()
    {
        _particleSystem.Play();
    }
}
