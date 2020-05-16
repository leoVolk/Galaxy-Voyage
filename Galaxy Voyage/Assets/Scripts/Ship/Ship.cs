using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public class ShipSpecifications
{
    public float throttleAcceleration = 10;
    public float strafeAcceleration = 10;
    public float rotationalAcceleration = 1.5f;
}

[RequireComponent(typeof(ShipController))]
public class Ship : MonoBehaviour
{
    [Header("Ship States")]
    public bool isPlayer = false;
    protected ShipInput input;
    protected ShipController controller;

    public static Ship PlayerShip { get { return playerShip; } }
    private static Ship playerShip;
    public float Throttle { get { return input.throttle; } }

    [Header("Ship Properties")]
    public ShipSpecifications specifications;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    protected void Awake()
    {
        input = GetComponent<ShipInput>();
        controller = GetComponent<ShipController>();
        if(isPlayer)
            playerShip = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayer)
        {
            if (Input.GetKey(KeyCode.Space))
                TimeManager._instance.DoSlowmotion();

            controller.ApplyInput(input.throttle * specifications.throttleAcceleration, input.strafe * specifications.strafeAcceleration, input.rotation * specifications.rotationalAcceleration);

            controller.SetMousePosition(Utils.GetMousePositon(transform));
            
        }
    }
}
