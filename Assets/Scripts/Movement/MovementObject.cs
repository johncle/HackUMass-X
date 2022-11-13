using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class MovementObject : EntityObject
{
    protected Vector2 movement;

    // unity automatically calls this every frame
    protected virtual void Update() {
        movement.x = Random.Range(-0.5f, 0.5f);
        movement.y = Random.Range(-0.5f, 0.5f);
    }

    // unity automatically calls this every 0.02 seconds (better for smooth physics)
    protected virtual void FixedUpdate() {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        // TODO: add collision
    }
}