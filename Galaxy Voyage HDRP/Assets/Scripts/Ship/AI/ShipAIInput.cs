using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAIInput : ShipInput
{
    private const float THROTTLE_SPEED = 0.25f;
    private const float ROTATION_SPEED = 1f;
    public void UpdateThrottle(Direction dir)
    {
        float target = throttle;

        if (dir == Direction.Forward)
            target = 1.0f;
        else if (dir == Direction.Backward)
            target = 0.0f;
        else
            target = 0;

        throttle = Mathf.MoveTowards(throttle, target, Time.deltaTime * THROTTLE_SPEED);
    }

    public void UpdateRotation(Direction dir)
    {
        float target = rotation;
        if (dir == Direction.Right)
            target = 1.0f;
        else if (dir == Direction.Left)
            target = -1.0f;
        else
            target = 0;

        rotation = Mathf.MoveTowards(rotation, target, Time.deltaTime * ROTATION_SPEED);
    }
}
