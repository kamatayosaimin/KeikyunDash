using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Random のすごーい Class
/// </summary>
public static class RandomGOIS
{

    public static float Lerp(float a, float b)
    {
        return Lerp(a, b, Mathf.Lerp);
    }

    public static float Get01()
    {
        return Random.Range(0f, 1f);
    }

    /// <summary>
    /// <see cref="bool"/> を Random で取得
    /// </summary>
    /// <returns></returns>
    public static bool GetBoolean()
    {
        bool[] values = new[]
        {
            false,
            true
        };

        return GetValue(values);
    }

    public static bool Probability(int denominator)
    {
        return Probability(1, denominator);
    }

    public static bool Probability(int numerator, int denominator)
    {
        return Random.Range(0, denominator) < numerator;
    }

    public static Vector2 Lerp(Vector2 a, Vector2 b)
    {
        return Lerp(a, b, Vector2.Lerp);
    }

    public static Vector3 Lerp(Vector3 a, Vector3 b)
    {
        return Lerp(a, b, Vector3.Lerp);
    }

    public static Vector3 Lerp(Transform a, Transform b, Func<Transform, Vector3> selector)
    {
        return Lerp(selector(a), selector(b));
    }

    public static Vector4 Lerp(Vector4 a, Vector4 b)
    {
        return Lerp(a, b, Vector4.Lerp);
    }

    ///// <summary>
    ///// 指定した Enum 型を Random で取得
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    ///// <returns></returns>
    //public static T GetEnum<T>()
    //{
    //    return GetValue(EnumGOIS.GetValues<T>());
    //}

    /// <summary>
    /// Collection の要素を Random で取得
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    public static T GetValue<T>(IEnumerable<T> values)
    {
        return values.ElementAt(Random.Range(0, values.Count()));
    }

    static T Lerp<T>(T a, T b, Func<T, T, float, T> selector) where T : struct
    {
        return selector(a, b, Get01());
    }
}
