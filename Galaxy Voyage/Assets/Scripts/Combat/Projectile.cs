using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 30;
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
    }
}
