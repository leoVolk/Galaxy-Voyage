using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Cannon
{
    private float timeToNextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        RotateSpawner();
    }

    void RotateSpawner(){
        Vector3 lookAtPos = Ship.PlayerShip.MousePosition - transform.position;
        

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
