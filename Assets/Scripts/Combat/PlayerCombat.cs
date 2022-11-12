using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CombatObject
{
    private bool unlockedPunch, unlockedKick;
    private Shout shout;
    private Punch punch;
    private Kick kick;
    private float nextAttackTime;
    private Transform shoutPoint, punchPoint, kickPoint;
    private Animator animator;

    protected void Start()
    {
        unlockedPunch = false;
        unlockedKick = false;
        shout = gameObject.AddComponent(typeof(Shout)) as Shout;
        punch = gameObject.AddComponent(typeof(Punch)) as Punch;
        kick = gameObject.AddComponent(typeof(Kick)) as Kick;
        nextAttackTime = 0f;
        animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        if (Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.J))
            {
                ShoutAttack();
                nextAttackTime = Time.time + shout.attackRate;
            }
            else if (Input.GetKeyDown(KeyCode.K) && unlockedPunch)
            {
                PunchAttack();
                nextAttackTime = Time.time + punch.attackRate;
            }
            else if (Input.GetKeyDown(KeyCode.L) && unlockedKick)
            {
                KickAttack();
                nextAttackTime = Time.time + kick.attackRate;
            }
        }
    }

    protected void ShoutAttack()
    {
        animator.SetTrigger("Shout");
        Attack(shoutPoint, shout.attackRange, shout.attackDamage);
    }

    protected void PunchAttack()
    {
        animator.SetTrigger("Punch");
        Attack(punchPoint, punch.attackRange, punch.attackDamage);
    }

    protected void KickAttack()
    {
        animator.SetTrigger("Kick");
        Attack(kickPoint, kick.attackRange, kick.attackDamage);
    }

    protected void OnDrawGizmosSelected()
    {
        if (shoutPoint == null) return;
        Gizmos.DrawWireSphere(shoutPoint.position, shout.attackRange);
        if (punchPoint == null) return;
        Gizmos.DrawWireSphere(punchPoint.position, punch.attackRange);
        if (kickPoint == null) return;
        Gizmos.DrawWireSphere(kickPoint.position, kick.attackRange);
    }
}