using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 150f;
    public float maxSpeed = 8f;
    public float idleFriction = 0.8f;

    public float Health {
        set {
            health = value;
            if (health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 10;
    public PunchAttack punchAttack;
    public GameObject punchHitbox;

    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    Collider2D punchCollider;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool isMoving = false;
    bool IsMoving {
        set {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }
    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        punchCollider = punchHitbox.GetComponent<Collider2D>();
    }

    private void FixedUpdate() {
        if (movementInput != Vector2.zero) {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (movementInput * moveSpeed * Time.fixedDeltaTime), maxSpeed);
            
            if (movementInput.x < 0) {
                spriteRenderer.flipX = true;
                // Debug.Log("facingLeft");
            } else if (movementInput.x > 0) {
                spriteRenderer.flipX = false;
                // Debug.Log("facingRight");
            }

            IsMoving = true;
        } else {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            IsMoving = false;
        }
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire() {
        PunchAttack();
    }

    public void PunchAttack() {
        animator.SetTrigger("punchAttack");
        if(spriteRenderer.flipX == true){
            punchAttack.AttackLeft();
        } else {
            punchAttack.AttackRight();
        }

        EndPunchAttack();
        Debug.Log("Punch");
    }

    public void EndPunchAttack() {
        punchAttack.StopAttack();
    }

    void LockMovement() {
        canMove = false;
    }

    void UnlockMovement() {
        canMove = true;
    }

    public void Defeated(){
        animator.SetTrigger("Defeated");
    }

}
