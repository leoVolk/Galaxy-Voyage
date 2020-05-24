using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotable : MonoBehaviour
{
    public Message onSpotMessage;

    public void Spotted()
    {
        Messenger._instance.OpenMessenger(onSpotMessage);
    }
}
