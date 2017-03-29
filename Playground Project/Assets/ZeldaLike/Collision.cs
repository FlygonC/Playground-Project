using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct CircleCollider
{
    public Vector2 position;
    public float radius;

    public CircleCollider(Vector2 _pos, float _rad)
    {
        position = _pos;
        radius = _rad;
    }

    public bool Collision(CircleCollider _other)
    {
        return (position - _other.position).magnitude <= radius + _other.radius;
    }

    public bool Collision(Vector2 _other)
    {
        return (position - _other).magnitude <= radius;
    }
    public bool Collision(Vector2[] _other)
    {
        foreach (Vector2 i in _other)
        {
            if (this.Collision(i))
            {
                return true;
            }
        }
        return false;
    }
    public bool Collision(List<Vector2> _other)
    {
        foreach (Vector2 i in _other)
        {
            if (this.Collision(i))
            {
                return true;
            }
        }
        return false;
    }

    /*public bool CollisionLine(Vector2 A, Vector2 B)
    {
        // D = normal of LineAB
        Vector2 D = (B - A).normalized;
        // t = closest point on AB to circle center
        float t = D.x * (position.x - A.x) + D.y * (position.y - A.y);
        //Debug.Log(t);
        if (t < -radius / 2 || t > (B - A).magnitude + (radius / 2))
        {
            return false;
        }
        // E = closest point on AB to circle center
        Vector2 E = t * D + A;

        float EtoC = (position - E).magnitude;

        return EtoC < radius;

    }*/
}