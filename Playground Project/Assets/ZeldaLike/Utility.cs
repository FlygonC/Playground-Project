using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Utility
{

    public static Vector2 AngleToVector(float _angleRad)
    {
        return new Vector2(Mathf.Sin(_angleRad), Mathf.Cos(_angleRad));
    }

    public static Vector2 DirectionToVector(Direction _face)
    {
        switch (_face)
        {
            case Direction.North:
                return new Vector2(0, 1);
            case Direction.East:
                return new Vector2(1, 0);
            case Direction.South:
                return new Vector2(0, -1);
            case Direction.West:
                return new Vector2(-1, 0);
            default:
                return new Vector2();
        }
    }
    public static Direction VectorToDirection(Vector2 vec)
    {
        if (Mathf.Abs(vec.x) > Mathf.Abs(vec.y))
        {
            if (vec.x < 0)
            {
                return Direction.West;
            }
            else
            {
                return Direction.East;
            }
        }
        else
        {
            if (vec.y < 0)
            {
                return Direction.South;
            }
            else
            {
                return Direction.North;
            }
        }
    }

    public static float Distance(Vector2 one, Vector2 two)
    {
        return (two - one).magnitude;
    }

    public static bool CircleLineCollision(CircleCollider Circle, Vector2 PointA, Vector2 PointB)
    {
        Vector2 C = Circle.position;// Center of circle

        // D = normal/direction of LineAB
        Vector2 D = (PointB - PointA).normalized;
        // t = distance from A to closest point on AB to C
        float t = D.x * (C.x - PointA.x) + D.y * (C.y - PointA.y);
        // E = closest point on AB to circle center
        Vector2 E = t * D + PointA;
        // EtoC = magnitude of Line EC
        float EtoC = (Circle.position - E).magnitude;


        //plane = EtoC < circle.radius;

        //alligned = (t > 0 && t < (pointB - pointA).magnitude);

        //hitting = alligned && plane;
        return EtoC < Circle.radius && (t > 0 && t < (PointB - PointA).magnitude);
    }

    public static Vector2 Mean(List<Vector2> vec)
    {
        Vector2 final = new Vector2();
        foreach (Vector2 i in vec)
        {
            final += i;
        }
        return final / vec.Count;
    }
}
