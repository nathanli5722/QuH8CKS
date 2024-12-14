using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attack1Damage;
    [SerializeField] private float attack2Damage;
    [SerializeField] private float attack3Damage;
    [SerializeField] private float attack4Damage;
    private GameObject enemy;
    private EnemyStats enemyStats;
    private void Start() {
        enemy = GameObject.FindWithTag("enemy");
        enemyStats = enemy.GetComponent<EnemyStats>();
    }

    public void Attack1() {
        enemyStats.hp -= attack1Damage;
        Debug.Log("Enemy hp: " + enemyStats.hp);
    }
    public void Attack2() {
        enemyStats.hp -= attack2Damage;
        Debug.Log("Enemy hp: " + enemyStats.hp);
    }
    public void Attack3() {
        enemyStats.hp -= attack3Damage;
        Debug.Log("Enemy hp: " + enemyStats.hp);
    }
    public void Attack4() {
        enemyStats.hp -= attack4Damage;
        Debug.Log("Enemy hp: " + enemyStats.hp);
    }

}
