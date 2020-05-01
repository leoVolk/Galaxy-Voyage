using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask ignore;
    public float projectileSpeed = 30;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        ignore = ~ignore;
    }
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, ignore))
        {
            print(hit.transform.name);
           // Destroy(this.gameObject);
        }
    }
}
