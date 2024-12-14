using System;
using System.Collections;
using TMPro;
using UnityEditor.Callbacks;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackTime;
    private GameObject UI;
    private Transform button1, button2, button3, button4;
    [SerializeField] private TMP_Text playerText, enemyText;

    private bool playerTurn;
    private Vector2 playerStartPos;
    private Vector2 enemyStartPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI = GameObject.Find("UI");
        button1 = UI.transform.GetChild(1);
        button2 = UI.transform.GetChild(2);
        button3 = UI.transform.GetChild(3);
        button4 = UI.transform.GetChild(4);

        playerStartPos = new Vector2((Camera.main.orthographicSize * -Screen.width / Screen.height) + 3, 0);
        player.transform.position = playerStartPos;
        player.transform.localScale = new Vector3(-1, 1, 1);

        enemyStartPos = new Vector2((Camera.main.orthographicSize * Screen.width / Screen.height) - 3, 0);
        enemy.transform.position = enemyStartPos;

        playerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Testing
        /*
        if (Input.GetKeyDown(KeyCode.P)) {
            StartCoroutine(AttackAnimation(player, enemy));
        } 
        if (Input.GetKeyDown(KeyCode.O)) {
            StartCoroutine(AttackAnimation(enemy, player));
        }
        */
        playerText.text = player.GetComponent<Stats>().hp.ToString();
        enemyText.text = enemy.GetComponent<EnemyStats>().hp.ToString();
        if (!playerTurn) {
            StartCoroutine(EnemyAttack());
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            SceneManager.LoadScene(0);
        }      
    }

    private void FixedUpdate() {
        
    }

    public void DoAttackAnimation() {
        StartCoroutine(AttackAnimation(player, enemy));
        playerTurn = false;
    }

    public IEnumerator AttackAnimation(GameObject attacker, GameObject receiver) {
        Vector2 direction = receiver.transform.position - attacker.transform.position;
        direction = direction.normalized * attackSpeed;
        attacker.GetComponent<Rigidbody2D>().linearVelocity = direction;
        yield return new WaitForSeconds(attackTime);
        if (attacker.Equals(player)) {
            attacker.transform.position = playerStartPos;
        }
        else {
            attacker.transform.position = enemyStartPos;
        }
        attacker.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
    }

    IEnumerator EnemyAttack() {
        playerTurn = true;
        UI.SetActive(false);
        yield return new WaitForSeconds(2);
        StartCoroutine(AttackAnimation(enemy, player));
        enemy.GetComponent<enemyAI>().doAttack();
        player.GetComponent<Stats>().hp -= enemy.GetComponent<EnemyStats>().damage;
        yield return new WaitForSeconds(3);
        UI.SetActive(true);
    }
}
