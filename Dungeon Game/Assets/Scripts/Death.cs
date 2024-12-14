using System.Collections;
using System;
using UnityEngine;

public class Death : MonoBehaviour
{
    private float timer = 1f;
    [SerializeField]
    private float speed = 1;
    Material mat;
    private int timerID;
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        timerID = Shader.PropertyToID("_Timer");
    }

    [ContextMenu("Start Death")]
    public void StartDeath()
    {
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        while (timer > 0)
        {
            timer -= speed * Time.deltaTime;
            mat.SetFloat(timerID, timer);
            yield return null;
        }
    }
}
