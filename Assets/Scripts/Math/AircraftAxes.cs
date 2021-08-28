using UnityEngine;

public static class AircraftAxes
{
    public static float Yaw(Vector3 direction)
    {
        return Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    }

    public static float Pitch(Vector3 direction)
    {
        return Mathf.Clamp(-Mathf.Asin(direction.normalized.y) * Mathf.Rad2Deg, -90, 90);
    }
}
