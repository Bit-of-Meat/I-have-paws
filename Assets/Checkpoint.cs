using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    [SerializeField] private Animator anim;
    [SerializeField] private float _timeStartAnimation;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //gm.lastCheckPoint = gameObject;
            gm.lastCheckPointPos = transform.position;
            StartCoroutine(Saved());
        }
    }
    IEnumerator Saved()
    {
        anim.SetTrigger("Activate");
        yield return new WaitForSeconds(_timeStartAnimation);
        gameObject.SetActive(false);
    }

}
