using UnityEngine;
using TMPro;

/// <summary>
/// Shows throttle and speed of the player ship.
/// </summary>
public class SpeedUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null && Ship.PlayerShip != null)
        {
            text.text = string.Format("Thrust: {0}\n", (Ship.PlayerShip.Throttle * 100.0f).ToString("000"));
        }
    }
}