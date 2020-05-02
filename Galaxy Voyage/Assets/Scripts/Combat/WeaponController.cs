using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(WeaponInput))]
public class WeaponController : MonoBehaviour
{
    [Header("Components")]
    public List<Weapon> weapons;

    //[HideInInspector]
    public Weapon currentWeapon;

    private int weaponIndex = 0;

    void Start()
    {
        if (weapons.Count == 0)
        {
            weapons.AddRange(GetComponentsInChildren<Weapon>());
        }

        currentWeapon = weapons[0];
    }

    public void SwitchWeaponDown()
    {
        if (weaponIndex == 0)
        {
            weaponIndex = weapons.Count - 1;
        }
        else
        {
            weaponIndex--;
        }

        currentWeapon = weapons[weaponIndex];
    }

    public void SwitchWeaponUp()
    {
        if (weaponIndex == weapons.Count - 1)
        {
            weaponIndex = 0;
        }
        else
        {
            weaponIndex++;
        }

        currentWeapon = weapons[weaponIndex];
    }

    /// <summary>
    /// clunky gameplay
    /// calculate angle between mouse position and transform forward
    /// set weaponry accordingly
    /// </summary>
    public void SetWeaponBasedOnAngle()
    {
        float angle = AngleDir();
        
        if (angle <= -30f)
        {
            // set to port weaponry
            currentWeapon = weapons[0];
        }
        else if (angle >= 30f)
        {
            // set to starboard weaponry
            currentWeapon = weapons[1];
        }
        else if(angle > -30 && angle < 30f)
        {
            //set to forward weaponry
            currentWeapon = weapons[2];
        }
    }

    float AngleDir()
    {
        return Vector3.SignedAngle(transform.forward, Ship.PlayerShip.MousePosition - transform.position, transform.up);
    }
}
