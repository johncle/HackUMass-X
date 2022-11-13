using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityObject : MonoBehaviour
{
    public int maxHp = 100;
    int currHp;
    public float moveSpeed = 8f;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    protected virtual void Start()
    {
        currHp = maxHp;
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public virtual void TakeDamage(int damage)
    {
        currHp -= damage;
        if (currHp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log("Die");
    }
}
