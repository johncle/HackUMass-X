using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovementObject
{
    private Animator animator;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected override void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
}
