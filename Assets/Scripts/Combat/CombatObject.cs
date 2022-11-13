using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatObject : EntityObject
{
    // deal attackDamage to enemies within attackRange of attackPoint
    protected void Attack(Transform attackPoint, float attackRange, int attackDamage)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EntityObject>().TakeDamage(attackDamage);
        }
    }
}
