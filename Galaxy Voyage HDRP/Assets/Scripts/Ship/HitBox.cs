using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private ShipController controller;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        controller = transform.GetComponentInParent<ShipController>();
    }

    
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
            return;
        else if(other.tag != "Player")
            controller.AddToCollsions(other);
    }

    void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
            return;
        else if(other.tag != "Player")
            controller.RemoveFromCollsions(other);
    }
}
