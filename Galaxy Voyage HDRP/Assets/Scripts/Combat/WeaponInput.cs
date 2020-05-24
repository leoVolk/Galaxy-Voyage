using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(WeaponController))]
public class WeaponInput : MonoBehaviour
{
    public LayerMask ignore;
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
        if (Input.GetKey(fireInput))
            TryShoot();
        else
            controller.ShootWeaponsBasedOnAngle(false);

        controller.SetWeaponBasedOnAngle();
    }

    void TryShoot()
    {
        if(!EventSystem.current.IsPointerOverGameObject()){
            controller.ShootWeaponsBasedOnAngle(true);
        }


    }
}
