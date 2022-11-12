using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseBasic : EntityObject
{
    protected override void Die()
    {
        // mutated goose dies, transforms into normal goose
        base.Die();
    }
}
