using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Spotter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Spotable spottable;
        if(other.TryGetComponent<Spotable>(out spottable)){
            spottable.Spotted();
        }
    }

}
