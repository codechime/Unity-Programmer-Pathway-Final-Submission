using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityContoller : MonoBehaviour
{
    // This is the object that will respond to input
    [SerializeField]
    private GameObject controllableEntity;

    // The distance to move in the horizontal direction
    protected float horizontalDelta = 0;

    // The maximum/minimum x (Horizontal Bound) of the object being moved
    protected float horizontalBound = float.MaxValue;

    // The distance to move in the vertical direction
    protected float verticalDelta = 0;

    // The maximum/minimum z (Vertical Bound) of the object being moved
    protected float verticalBound = float.MaxValue;

    protected bool destroyOnOutOfBounds = false;

    protected bool useHorizontalInput = false;

    // ABSTRACTION
    bool IsOutOfBounds(Vector3 positionDelta)
    {
        Vector3 proposedPosition = transform.position + positionDelta;
        if (proposedPosition.x > horizontalBound || proposedPosition.x < -horizontalBound)
        {
            return true;
        }
        if (proposedPosition.z > verticalBound || proposedPosition.z < -verticalBound)
        {
            return true;
        }
        return false;
    }

    // POLYMORPHISM
    protected void Instantiate(GameObject item)
    {
        Instantiate(item, transform.position,
                    item.transform.rotation);
    }

    // ABSTRACTION
    protected void Update()
    {
        // Get a value for horizontal input
        float horizontalInput = 0;
        if(useHorizontalInput)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }

        // Calculate quantum of displacement
        float horizontalDisplacement = horizontalInput * horizontalDelta * Time.deltaTime;
        float verticalDisplacement = verticalDelta * Time.deltaTime;

        // Make an additive vector from displacement
        Vector3 positionDelta = new Vector3(horizontalDisplacement, 0, verticalDisplacement);

        // Check if out of bounds
        if(IsOutOfBounds(positionDelta))
        {
            if(destroyOnOutOfBounds)
            {
                Destroy(gameObject);
            }
            return;
        }

        // Move the object
        transform.position += positionDelta;
    }
}
