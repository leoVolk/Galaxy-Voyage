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
        controller.ShootWeaponsBasedOnAngle(Input.GetKey(fireInput));
        controller.SetWeaponBasedOnAngle();
    }
}
