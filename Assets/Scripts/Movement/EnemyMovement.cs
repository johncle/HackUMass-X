using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MovementObject
{
    public float stoppingDist;
    private Transform target;

    protected override void Start()
    {
        // find player object
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        stoppingDist = 1;
    }   

    protected override void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDist)
        {
            // move towards player
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}