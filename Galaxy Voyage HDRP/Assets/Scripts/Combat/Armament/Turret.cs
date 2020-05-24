using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Cannon
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        RotateSpawner();
    }

    /// <summary>
    /// TODO: Fix turret rotation
    /// </summary>
    void RotateSpawner(){
        Vector3 lookAtPos = Utils.GetMousePositon(transform);
        

        foreach(Transform t in projectileSpawner){
            t.LookAt(lookAtPos);
        }
    }

    public override void TryShoot()
    {
        if (heatLevel < 100 && Time.time >= timeToNextFire && !isOverheated)
        {
            
            timeToNextFire = Time.time + 60f / fireRate;
            heatLevel += heatBuildUp;
            ShootProjectile();
            
            SwitchSpawnerIndex();
            //SetToRandomWeaponIndex();
        }

        if (heatLevel >= 100)
        {
            isOverheated = true;
        }
    }
}
