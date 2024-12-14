using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Sceners : MonoBehaviour
{
    [SerializeField] private List<GameObject> Scenes;
    GameObject prevScene;
    private int i = 0;
    void Start()
    {
        prevScene = Instantiate(Scenes[i]);
        prevScene.transform.localScale *= 2;
        prevScene.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(1);
        }
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
        }
        */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            i++;
            Destroy(prevScene);
            prevScene = Instantiate(Scenes[i]);
            prevScene.transform.localScale *= 2;
            prevScene.SetActive(true);
        }
    }
}