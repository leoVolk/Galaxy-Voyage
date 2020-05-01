using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponController))]
public class WeaponInput : MonoBehaviour
{
    [Header("Input Keys")]
    public KeyCode fireInput;
    private WeaponController controller;

    void Awake()
    {
        controller = GetComponent<WeaponController>();
    }


    // Update is called once per frame
    void Update()
    {
        controller.currentWeapon.isFiring = Input.GetKey(fireInput);

        if(Input.GetAxis("Mouse ScrollWheel") < 0){
            controller.SwitchWeaponDown();
        }else if(Input.GetAxis("Mouse ScrollWheel") > 0){
            controller.SwitchWeaponUp();
        }
    }
}
