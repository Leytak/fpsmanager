using UnityEngine;

public class AircraftAxes
{
    public float Yaw { get; private set; }
    public float Pitch { get; private set; }

    public AircraftAxes(float yaw, float pitch)
    {
        Yaw = yaw;
        Pitch = pitch;
    }

    public AircraftAxes(Vector3 direction)
    {
        Yaw = DirectionToYaw(direction);
        Pitch = DirectionToPitch(direction);
    }

    public static float DirectionToYaw(Vector3 direction)
    {
        return Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    }

    public static float DirectionToPitch(Vector3 direction)
    {
        return Mathf.Clamp(-Mathf.Asin(direction.normalized.y) * Mathf.Rad2Deg, -90, 90);
    }

    public override string ToString()
    {
        return $"({Yaw}, {Pitch})";
    }
}
