using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Components")]
    public Transform[] projectileSpawner;

    [Header("Weapon States")]
    public bool isFiring;


    protected int currentSpawnerIndex = 0;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>

    public virtual void TryShoot() { }
    public virtual void DecreaseHeat() { }

    protected void SwitchSpawnerIndex()
    {
        if (currentSpawnerIndex == projectileSpawner.Length - 1)
        {
            currentSpawnerIndex = 0;
        }
        else
        {
            currentSpawnerIndex++;
        }
    }

    protected void SetToRandomWeaponIndex(){
        int lastSpawnIndex = currentSpawnerIndex;
        int nextSpawnIndex = currentSpawnerIndex;

        while(nextSpawnIndex == lastSpawnIndex){
            nextSpawnIndex = Random.Range(0, projectileSpawner.Length);
        }

        currentSpawnerIndex = nextSpawnIndex;
    }
}
