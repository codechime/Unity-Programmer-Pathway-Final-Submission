using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : EntityContoller
{
    // Start is called before the first frame update
    void Start()
    {
        verticalDelta = 20;
        verticalBound = 12;
        destroyOnOutOfBounds = true;
    }
}
