using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AI_Options
{
    public float distanceThreshold = 10;
    public float broadSideDistance = 10;
}

public class ShipAI : Ship
{
    public AI_Options AI;

    public Transform currentTarget;
    private ShipAIController controller;
    private ShipAIInput input;

    // Start is called before the first frame update
    new void Awake()
    {
        controller = GetComponent<ShipAIController>();
        input = GetComponent<ShipAIInput>();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustMovement();

        controller.ApplyInput(input.throttle * specifications.throttleAcceleration, input.strafe * specifications.strafeAcceleration, input.rotation * specifications.rotationalAcceleration);
    }

    private void AdjustMovement()
    {
        Vector3 rightSideTarget = currentTarget.position + currentTarget.right * AI.broadSideDistance;
        Vector3 leftSideTarget = currentTarget.position - currentTarget.right * AI.broadSideDistance;

        float distanceToTargetRight = Vector3.Distance(transform.position, rightSideTarget);
        float distanceToTargetLeft = Vector3.Distance(transform.position, leftSideTarget);

        if (distanceToTargetLeft > AI.distanceThreshold || distanceToTargetRight > AI.distanceThreshold)
        {
            if (distanceToTargetRight > distanceToTargetLeft)
            {
                //set left broadside to target and do shit (because less distance)
                input.UpdateThrottle(Direction.Forward);
            }
            else
            {
                //work with right broadside as target position (because less distance)
                input.UpdateThrottle(Direction.Forward);
            }
        }else{
            input.UpdateThrottle(Direction.None);
        }
    }


}
