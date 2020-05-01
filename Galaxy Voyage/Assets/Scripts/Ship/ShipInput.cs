using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ShipInput : MonoBehaviour
{
    [Header("Input Keys")]
    public KeyCode increaseThrust = KeyCode.W, decreaseThrust = KeyCode.S;

    [Header("Input States")]
    [HideInInspector]
    public float strafe;
    
    [ProgressBar("Throttle", 1, EColor.Indigo)]
    [ReadOnly]
    [Range(0, 1)]
    public float throttle;
    

    private Ship ship;
    private Camera playerCamera;
    private const float THROTTLE_SPEED = 0.25f;

    private void Awake()
    {
        ship = GetComponent<Ship>();
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateKeyboardThrottle(KeyCode.W, KeyCode.S);
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

    public Vector3 GetMousePos()
    {
        Vector3 lookAtPos = Input.mousePosition;
        lookAtPos.z = playerCamera.transform.position.y - transform.position.y;
        lookAtPos = playerCamera.ScreenToWorldPoint(lookAtPos);

        return lookAtPos;
    }
}
