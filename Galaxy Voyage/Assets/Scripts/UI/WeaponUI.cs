using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    public WeaponController weaponController;
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
            text.text = string.Format("Current Weapon:\n {0}", (weaponController.currentWeapon.name));
        }
    }
}
