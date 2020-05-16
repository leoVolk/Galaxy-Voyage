using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    private CharacterController controller;
    private float throttle;
    private float strafe;
    private float rotation;
    private Vector3 mousePos;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
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
        //transform.position += transform.forward * throttle * Time.deltaTime;
        //transform.position += transform.right * strafe * Time.deltaTime;
        controller.Move(transform.forward * throttle * Time.deltaTime);
    }


    void UpdateRotationWithKeyBoardInput(){
        transform.RotateAround(transform.position, transform.up, rotation * Time.deltaTime);
    }

    public void LookAtMousePos()
    {
        transform.forward = Vector3.Lerp(transform.forward, mousePos - transform.position, Time.deltaTime * rotation);
        
    }

    public void SetMousePosition(Vector3 mousePos){
        this.mousePos = mousePos;
    }

}
