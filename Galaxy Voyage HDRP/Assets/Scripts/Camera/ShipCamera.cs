using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCamera : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraPosition();
    }

    void UpdateCameraPosition(){
        Vector3 targetPos = target.position;
        targetPos.y = transform.position.y;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
    }
}
