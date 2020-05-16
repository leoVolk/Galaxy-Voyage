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
        if(Input.GetKey(fireInput))
            controller.ShootWeaponsBasedOnAngle(true);
        else
            controller.ShootWeaponsBasedOnAngle(false);
        
        controller.SetWeaponBasedOnAngle();
    }
}
