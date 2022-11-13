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

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            startMoving();

            oldPos = transform.position; //Save last position
            newPos = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); //Calculate new position

            if (newPos.x < oldPos.x) //Update directional flags
            {
                turnLeft();
            }
            else if (newPos.x > oldPos.x)
            {
                turnRight();
            }

            transform.position = newPos; //Update position
        }
        else
        {
            stopMoving();
        }
    }

    private void turnLeft()
    {
        animator.SetBool("leftFacing", true);
        animator.SetBool("rightFacing", false);
    }

    private void turnRight()
    {
        animator.SetBool("leftFacing", false);
        animator.SetBool("rightFacing", true);
    }

    private void startMoving()
    {
        animator.SetBool("isMoving", true);
    }

    private void stopMoving()
    {
        animator.SetBool("isMoving", false);
    }
}

