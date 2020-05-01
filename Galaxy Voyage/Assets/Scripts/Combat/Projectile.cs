using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask ignore;
    public float projectileSpeed = 30;
    public ParticleSystem impactEffect;

    void Start()
    {
        ignore = ~ignore;
    }
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, .25f, ignore))
        {
            Destroy(Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)).gameObject, 2f);
            Destroy(this.gameObject);
        }
    }
}
