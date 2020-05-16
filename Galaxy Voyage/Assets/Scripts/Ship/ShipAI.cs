using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAI : Ship
{
    [SerializeField]
    private Transform currenTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AdjustMovement();

        controller.ApplyInput(input.throttle * specifications.throttleAcceleration, input.strafe * specifications.strafeAcceleration, input.rotation * specifications.rotationalAcceleration);
    }

    private void AdjustMovement()
    {
        float distanceToTarget = Vector3.Distance(transform.position, currenTarget.position);
        float angle = AngleDir();

    }

    float AngleDir()
    {
        return Vector3.SignedAngle(transform.forward, currenTarget.position - transform.position, transform.up);
    }


}
