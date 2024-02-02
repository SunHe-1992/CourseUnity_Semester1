using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathUtil
{

    public static int GenerateRandomFloat(int minVal, int maxVal)
    {
        return Random.Range(minVal, maxVal);
    }
    public static Vector3 GenerateRandomVector3(float magnitude)
    {
        int xValue = GenerateRandomFloat(-100, 100);
        int zValue = GenerateRandomFloat(-100, 100);

        Vector3 vect = new Vector3(xValue, 0, zValue);
        return vect.normalized * magnitude;
    }

}
