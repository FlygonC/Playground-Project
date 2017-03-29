using UnityEngine;
using System.Collections;

public static class FreeRNG {

    public const uint MaxUInt = 4294967295;

    private static uint number = (uint)Random.Range(0, MaxUInt);

	public static uint Generate()
    {
        number = CustomRandom.CoreGenerator(number);
        return number;
    }

    public static float FloatRange(float min, float max)
    {
        //float random = (float)Generate();
        float normal = (float)Generate() / MaxUInt;

        return min + (normal * (max - min));
    }

    public static bool CoinFlip()
    {
        return (Generate() % 2) == 0;
    }

}
