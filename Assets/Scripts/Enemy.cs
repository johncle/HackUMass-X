using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    Animator animator;
    Rigidbody2D rb;

    public float Health {
        set {
            _health = value;

            if(_health <= 0) {
                Defeated();
            }
        }
        get {
            return _health;
        }
    }

    public float _health = 10;

    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnHit(float damage) {
        Health -= damage;
        Debug.Log(Health);
    }

    public void OnHit(float damage, Vector2 knockback) {
        Health -= damage;
        rb.AddForce(knockback);
        Debug.Log(Health + " " + rb.position);
    }

    public void Defeated(){
        // animator.SetTrigger("Defeated");
        Debug.Log("Die");
        Die();
    }

    public void Die() {
        GameObject.Destroy(gameObject);
    }
}
