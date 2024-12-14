using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] public float hp;
    [SerializeField] public float speed;
    [SerializeField] public float damage;
    public bool isDead() => hp <= 0;
}
