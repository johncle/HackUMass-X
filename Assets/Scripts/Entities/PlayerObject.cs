using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : EntityObject
{
    protected override void Die()
    {
        Debug.Log("Game Over");
    }
}
