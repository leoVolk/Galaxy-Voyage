using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    private static Camera cam = Camera.main;
    /// <summary>
    /// Get Mouse Position relative to World Space
    /// </summary>
    /// <param name="fromPos">orign</param>
    /// <returns></returns>
    public static Vector3 GetMousePositon(Transform fromPos)
    {
        Vector3 lookAtPos = Input.mousePosition;
        if (cam != null)
            lookAtPos.z = cam.transform.position.y - fromPos.position.y;

        lookAtPos = cam.ScreenToWorldPoint(lookAtPos);

        return lookAtPos;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="from">Origin</param>
    /// <param name="to">target</param>
    /// <returns></returns>
    public static float AngleDir(Transform from, Transform to)
    {
        return Vector3.SignedAngle(from.forward, to.position - from.position, from.up);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="from">Origin</param>
    /// <param name="to">target</param>
    /// <returns></returns>
    public static float AngleDir(Transform from, Vector3 to)
    {
        return Vector3.SignedAngle(from.forward, to - from.position, from.up);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="from">origin</param>
    /// <returns></returns>
    public static float AngleDir(Transform from)
    {
        return Vector3.SignedAngle(from.forward, GetMousePositon(from) - from.position, from.up);
    }
}
