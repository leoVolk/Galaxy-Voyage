using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineLight : MonoBehaviour
{
    public Ship ship;
    public Light lightSource;
    // Start is called before the first frame update
    void Start()
    {
        if(ship == null){
            ship = Ship.PlayerShip;
        }

        if(lightSource == null){
            lightSource = GetComponentInChildren<Light>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetIntensityBasedOnThrottle();
    }

    void SetIntensityBasedOnThrottle(){
        lightSource.intensity = Ship.PlayerShip.Throttle *2;
    }
}
