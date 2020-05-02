using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Cannon : Weapon
{
    [Header("Projectile Weapon Components")]
    public Projectile projectilePrefab;
    public ParticleSystem muzzleFlash;

    [Header("Projectile Weapon Properties")]
    public float fireRate = 500;
    public float heatBuildUp = 1f;
    public float heatReduction = .25f;

    [ProgressBar("Heat", 100, EColor.Red)]
    [ReadOnly]
    public float heatLevel;
    [Header("Projectile Weapon States")]
    [ReadOnly]
    public bool isOverheated = false;


    private WeaponController controller;
    private float timeToNextFire = 0f;

    protected void Start()
    {
        controller = GetComponentInParent<WeaponController>();
    }

    protected void Update()
    {
        if (isFiring && controller.currentWeapons.Contains(this))
            TryShoot();

        if (!isFiring || isOverheated)
            DecreaseHeat();

    }

    public override void TryShoot()
    {
        if (heatLevel < 100 && Time.time >= timeToNextFire && !isOverheated)
        {
            
            timeToNextFire = Time.time + 60f / fireRate;
            for (int i = 0; i < projectileSpawner.Length; i++)
            {
                currentSpawnerIndex = i; 
                heatLevel += heatBuildUp;
                ShootProjectile();
            }
            
            //SwitchSpawnerIndex();
            // SetToRandomWeaponIndex();
        }

        if (heatLevel >= 100)
        {
            isOverheated = true;
        }
    }

    protected void ShootProjectile()
    {
        PlayMuzzleFlashAtSpawner();
        Destroy(Instantiate(projectilePrefab, projectileSpawner[currentSpawnerIndex].position, Quaternion.LookRotation(projectileSpawner[currentSpawnerIndex].forward)).gameObject, 2f);
    }

    public override void DecreaseHeat()
    {
        if (isOverheated)
        {
            isOverheated = heatLevel != 0;
        }

        heatLevel = Mathf.MoveTowards(heatLevel, 0, Time.deltaTime * heatReduction * 10);
        heatLevel = Mathf.Clamp(heatLevel, 0, 100);
    }

    void PlayMuzzleFlashAtSpawner(){
        if(muzzleFlash != null){
            muzzleFlash.transform.position = projectileSpawner[currentSpawnerIndex].position;
            muzzleFlash.Play();
        }
    }


}
