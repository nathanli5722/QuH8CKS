
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class enemyAI : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    private Stats playerStats;
    private EnemyStats stats;
    // Update is called once per frame
    void Start()
    {
        stats = GetComponent<EnemyStats>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    }
    public void doAttack()
    {
        int random  = Random.Range(0, objects.Count);
        StartCoroutine(AIAttack(objects[random]));
        playerStats.hp -= stats.damage;
    }
    
    IEnumerator AIAttack(GameObject attackObj)
    {
        //Vector2 startPosReceiver = GameObject.FindWithTag("enemy").transform.position;
        Vector2 startPosReceiver = transform.position;
        // <1,2>
        GameObject obj = Instantiate(attackObj);
        obj.transform.position = new Vector2(transform.position.x, (Camera.main.orthographicSize * Screen.height / Screen.width) + 3);
        yield return new WaitForSeconds(1f);
        
        Destroy(obj);
    }
}
