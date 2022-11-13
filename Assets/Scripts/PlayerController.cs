using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    Vector2 movement;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (movement != Vector2.zero) {
            bool success = TryMove(movement);
            if (!success) {
                success = TryMove(new Vector2(movement.x, 0));
                if (!success) {
                    success = TryMove(new Vector2(0, movement.y));
                }
            }
        }
    }

    private bool TryMove(Vector2 dir) {
        int count = rb.Cast(
            movement,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset
        );
        if (count == 0) {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movement = movementValue.Get<Vector2>();
    }
}
