using UnityEngine;

public static class ManageAtLook
{
    public static void LookAt2DSmooth(this Transform me, Vector3 target, Vector3 eye, float intensity)
    {
        Vector3 look = target - me.position;
        float sAngle = Vector2.SignedAngle(eye, look);
        if (sAngle != 0.0f)
        {
            Vector3 eulerAngles = me.eulerAngles;
            eulerAngles.z = Mathf.Lerp(eulerAngles.z, eulerAngles.z + sAngle, intensity * Time.deltaTime);
            me.eulerAngles = eulerAngles;
        }
    }
}