using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityContoller
{
    [SerializeField]
    private GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        horizontalDelta = 20;
        horizontalBound = 21;
        useHorizontalInput = true;
    }

    new void Update()
    {
        base.Update();
        if(Input.GetKeyUp(KeyCode.Space))
        {
            // Launch a projectile
            Instantiate(projectilePrefab, transform.position,
                        projectilePrefab.transform.rotation);
        }
    }
}
