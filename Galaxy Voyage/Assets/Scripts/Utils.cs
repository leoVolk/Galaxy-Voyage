using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    private static Camera cam = Camera.main;
    public static Vector3 GetMousePositon(Transform fromPos)
    {
        Vector3 lookAtPos = Input.mousePosition;
        if (cam != null)
            lookAtPos.z = cam.transform.position.y - fromPos.position.y;

        lookAtPos = cam.ScreenToWorldPoint(lookAtPos);

        return lookAtPos;
    }
}
