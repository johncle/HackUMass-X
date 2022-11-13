using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchHitbox : MonoBehaviour
{
    public float damage = 2f;
    public float knockbackForce = 5000f;
    public Collider2D punchCollider;
    public Vector3 right = new Vector3(1, 0, 0);
    public Vector3 left = new Vector3(-1, 0, 0);

    void start() {
        if (punchCollider == null) {
            Debug.LogWarning("Collider not set");
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        IDamageable obj = col.GetComponent<IDamageable>();
        if (obj != null) {
            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
            Vector2 direction = (Vector2)(col.gameObject.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;
            obj.OnHit(damage, knockback);
        } else {
            Debug.Log("not damageable");
        }
    }

    void IsFacingRight(bool isFacingRight) {
        if (isFacingRight) {
            gameObject.transform.localPosition = right;
        } else {
            gameObject.transform.localPosition = left;
        }
    }

    // Vector2 CalcKnockback() {
    //     gameObject.character = gameObject.getPar;
    // }
}
