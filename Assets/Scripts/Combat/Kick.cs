using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    public int attackDamage;
    public float attackRange;
    public float attackRate;
    void Start()
    {
        attackDamage = 40;
        attackRange = 1;
        attackRate = 3f;
    }
}
