using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAttack : MonoBehaviour
{
    public float damage = 2;
    public Collider2D punchCollider;

    public void AttackRight() {
        Debug.Log("Right");
        punchCollider.enabled = true;
    }

    public void AttackLeft() {
        Debug.Log("Left");
        punchCollider.enabled = true;
    }

    public void StopAttack() {
        punchCollider.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.Health -= damage;
                Debug.Log(enemy.Health);
            }
        }
    }
}
