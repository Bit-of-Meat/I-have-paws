using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPos;
    //public GameObject lastCheckPoint;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //lastCheckPoint = GameObject.FindGameObjectWithTag("CheckPoint");
            //lastCheckPoint.SetActive(false);
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
