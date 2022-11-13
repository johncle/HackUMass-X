using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    public Transform target;

    Animator animator;

    private Vector3 oldPos;
    private Vector3 newPos;

    bool leftFacing = false;
    bool rightFacing = true;
    bool isMoving = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            isMoving = true;
            oldPos = transform.position;
            newPos = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            if (newPos.x < oldPos.x)
            {
                leftFacing = true;
                rightFacing = false;
            }
            else if (newPos.x > oldPos.x)
            {
                leftFacing = false;
                rightFacing = true;
            }
            transform.position = newPos;
        }
        else
        {
            isMoving = false;
        }
        animator.SetBool("leftFacing", leftFacing);
        animator.SetBool("rightFacing", rightFacing);
        animator.SetBool("isMoving", isMoving);
    }
}
