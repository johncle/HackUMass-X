using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAttack : MonoBehaviour
{
    public Collider2D punchCollider;
    public float damage = 2;
    Vector2 rightAttackOffset;

    private void Start() {
        rightAttackOffset = transform.position;
    }

    public void AttackRight() {
        punchCollider.enabled = true;
        transform.position = rightAttackOffset;
    }

    public void AttackLeft() {
        punchCollider.enabled = true;
        transform.position = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y * -1);
    }

    public void StopAttack() {
        punchCollider.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.Health -= damage;
            }
        }
    }
}
