using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponController : MonoBehaviour
{
    [Header("Components")]
    public List<Weapon> portArmament;
    public List<Weapon> starboardArmament;
    public List<Weapon> sternArmament;
    public List<Weapon> bowArmament;


    [Header("Info")]
    //[HideInInspector]
    public List<Weapon> currentWeapons;

    private int weaponIndex = 0;

    void Start()
    {

    }

    /// <summary>
    /// clunky gameplay
    /// calculate angle between mouse position and transform forward
    /// set weaponry accordingly
    /// </summary>
    public void SetWeaponBasedOnAngle()
    {
        float angle = AngleDir();

        if (angle <= -30f && angle >= -150f)
        {
            // set to port armament
            currentWeapons = portArmament;
        }
        else if (angle >= 30f && angle <= 150f)
        {
            // set to starboard armament
            currentWeapons = starboardArmament;
        }
        else if (angle > -30f && angle < 30f)
        {
            if (bowArmament.Count > 0)
                // set to stern armament
                currentWeapons = bowArmament;
            else
                currentWeapons = null; ;
        }
        else if (angle > 150f || angle < -150f)
        {
            if (sternArmament.Count > 0)
                // set to stern armament
                currentWeapons = sternArmament;
            else
                currentWeapons = null;
        }
    }

    public void ShootWeaponsBasedOnAngle(bool firing)
    {
        if (currentWeapons != null)
        {
            if (currentWeapons.Count > 0)
            {
                foreach (Weapon weapon in currentWeapons)
                {
                    weapon.isFiring = firing;
                }
            }

        }
    }

    float AngleDir()
    {
        return Vector3.SignedAngle(transform.forward, Utils.GetMousePositon(transform) - transform.position, transform.up);
    }
}
