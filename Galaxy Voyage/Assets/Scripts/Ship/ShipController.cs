using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private float throttle;
    private float strafe;
    private float rotation;
    private Vector3 mousePos;



    void Awake()
    {
    }

    void Update()
    {
        //LookAtMousePos();
        UpdateRotationWithKeyBoardInput();
        UpdatePositionWithKeyboardInput();
    }

    public void ApplyInput(float throttle, float strafe, float rotation)
    {
        this.throttle = throttle;
        this.strafe = strafe;
        this.rotation = rotation;
    }

    void UpdatePositionWithKeyboardInput()
    {
        transform.position += transform.forward * throttle * Time.deltaTime;
        //transform.position += transform.right * strafe * Time.deltaTime;
    }


    void UpdateRotationWithKeyBoardInput()
    {
        transform.RotateAround(transform.position, transform.up, rotation * Time.deltaTime);
    }

    public void LookAtMousePos()
    {
        transform.forward = Vector3.Lerp(transform.forward, mousePos - transform.position, Time.deltaTime * rotation);

    }

    public void SetMousePosition(Vector3 mousePos)
    {
        this.mousePos = mousePos;
    }


    //TODO: find good way to check collision and thereby disable movement
    // or just leave it at that and let the play run the ship against walls while taking massive damage
    bool CheckCollision()
    {
        
        return false;
    }

}
