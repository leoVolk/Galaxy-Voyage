using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public bool isInStrategicView;

    private TimeManager timeManager;

    void Awake()
    {
        timeManager = GetComponent<TimeManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToStrategicView(){
        
    }

    public void SwitchToDefaultView(){

    }
}
