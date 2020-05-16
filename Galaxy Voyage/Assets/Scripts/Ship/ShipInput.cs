using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public enum Direction{
    Forward,
    Backward,
    Left,
    Right,
    None
}

public class ShipInput : MonoBehaviour
{
    [Header("Input Keys")]
    public KeyCode increaseThrust = KeyCode.W;
    public KeyCode decreaseThrust = KeyCode.S;
    public KeyCode increaseRotation = KeyCode.D;
    public KeyCode decreaseRotaion = KeyCode.A;
    public KeyCode fixedPosition = KeyCode.Mouse1;

    [Header("Input States")]
    [HideInInspector]
    public float strafe;

    [ProgressBar("Throttle", 1, EColor.Indigo)]
    [ReadOnly]
    [Range(0, 1)]
    public float throttle;

    [ProgressBar("Rotation", 1, EColor.Indigo)]
    [ReadOnly]
    [Range(0, 1)]
    public float rotation;

    private Ship ship;
    private const float THROTTLE_SPEED = 0.25f;
    private const float ROTATION_SPEED = 1f;

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ship.isPlayer)
        {
            UpdateKeyboardThrottle(KeyCode.W, KeyCode.S);
            UpdateKeyboardRotation(increaseRotation, decreaseRotaion);
        }
    }

    private void UpdateKeyboardThrottle(KeyCode increaseKey, KeyCode decreaseKey)
    {
        float target = throttle;

        if (Input.GetKey(increaseKey))
            target = 1.0f;
        else if (Input.GetKey(decreaseKey))
            target = 0.0f;
        else
            target = 0;

        throttle = Mathf.MoveTowards(throttle, target, Time.deltaTime * THROTTLE_SPEED);
    }

    private void UpdateKeyboardRotation(KeyCode increaseKey, KeyCode decreaseKey)
    {
        float target = rotation;

        if (Input.GetKey(increaseKey))
            target = 1.0f;
        else if (Input.GetKey(decreaseKey))
            target = -1.0f;
        else
            target = 0;

        rotation = Mathf.MoveTowards(rotation, target, Time.deltaTime * ROTATION_SPEED);
    }

    public void UpdateThrottle(Direction dir){
        float target = throttle;

        if (dir == Direction.Forward)
            target = 1.0f;
        else if (dir == Direction.Backward)
            target = 0.0f;
        else
            target = 0;

        throttle = Mathf.MoveTowards(throttle, target, Time.deltaTime * THROTTLE_SPEED);
    }

    public void UpdateRotation(Direction dir){
        float target = rotation;
        if(dir == Direction.Right)
            target = 1.0f;
        else if(dir == Direction.Left)
            target = -1.0f;
        else
            target = 0;

        rotation = Mathf.MoveTowards(rotation, target, Time.deltaTime * ROTATION_SPEED);
    }
    /// <summary>
    /// Deprecated, staying for possible feature use
    /// </summary>
    /// <param name="increaseKey"></param>
    /// <param name="decreaseKey"></param>
    private void UpdateKeyboardStrafe(KeyCode increaseKey, KeyCode decreaseKey)
    {
        float target = strafe;

        if (Input.GetKey(increaseKey))
            target = 1.0f;
        else if (Input.GetKey(decreaseKey))
            target = -1.0f;
        else
            target = 0;

        strafe = Mathf.MoveTowards(strafe, target, Time.deltaTime * THROTTLE_SPEED);
    }

}
