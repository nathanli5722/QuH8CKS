using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] public float hp;
    [SerializeField] private List<Attack> attacks;
    [SerializeField] public float speed;
}
