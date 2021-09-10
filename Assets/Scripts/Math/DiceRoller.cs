using UnityEngine;

public static class DiceRoller
{
    public static float Roll(float range)
    {
        return Random.value * range - Random.value * range;
    }
}
