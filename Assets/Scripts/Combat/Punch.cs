using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public int attackDamage;
    public float attackRange;
    public float attackRate;
    void Start()
    {
        attackDamage = 20;
        attackRange = 1;
        attackRate = 2f;
    }
}
