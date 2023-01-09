using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respwn : MonoBehaviour
{
    [SerializeField] private Slingshot _slingshot;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rbPlayer;
    [SerializeField] private Animator _animatorScren;
    [SerializeField] private bool _goNextScene = false;
    [SerializeField] private int _idNextScene;
    [SerializeField] private float _timeNextScene;
    [SerializeField] private float _timePritech;
    private bool _used = false;
    private Vector2 _posNext = Vector2.zero;
     

    private void Update()
    {
        if(_posNext != Vector2.zero) _rbPlayer.position = Vector2.Lerp(_rbPlayer.position, _posNext, _timePritech * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_used)
        {
            _rbPlayer.velocity = Vector2.zero;
            _slingshot.IsGround = true;
            _rbPlayer.isKinematic = true;
            _posNext = transform.position;
            _animator.SetBool("Jump", false);

            if (_goNextScene) StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene()
    {
        _animatorScren.SetTrigger("Hide");
        yield return new WaitForSeconds(_timeNextScene);
        SceneManager.LoadScene(_idNextScene);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _posNext = Vector2.zero;
        _used = true;
        _rbPlayer.isKinematic = false;
    }
}
