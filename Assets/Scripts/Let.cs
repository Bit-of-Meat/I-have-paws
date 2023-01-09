using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Let : MonoBehaviour
{
    [SerializeField] private string _tagPlayer = "Player";
    [SerializeField] private Animator _animatorScren;
    [SerializeField] private GameObject _effectDeath;
    [SerializeField] private float _waitForSecondsDeath = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == _tagPlayer)
        {   Instantiate(_effectDeath, collision.transform);
            StartCoroutine(DeathPlayer(collision.gameObject));
        }
    }

    private IEnumerator DeathPlayer(GameObject gameObject)
    {
        Destroy(gameObject);
        _animatorScren.SetTrigger("Hide");
        yield return new WaitForSeconds(_waitForSecondsDeath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
