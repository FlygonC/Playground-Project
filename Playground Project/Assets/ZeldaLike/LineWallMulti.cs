using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineWallMulti : MonoBehaviour
{

    public Vector2[] points;

    public bool closed;
    
    void Update()
    {
        foreach (Entity e in FindObjectsOfType<Entity>())
        {
            CircleCollider circle = e.hitbox;
            List<Vector2> compoundDisplacement = new List<Vector2>();
            bool hit = false;
            // Collision with Points
            for (int i = 0; i < points.Length; i++)
            {
                if (circle.Collision(points[i]))
                {
                    e.EntityPosition = points[i] + ((e.EntityPosition - points[i]).normalized * circle.radius);
                    //return;
                }
            }
            // Collision with Lines
            //FinishedE = false;
            for (int i = 0; i < points.Length - 1; i++)
            {
                // Start Line Circle Collision
                Vector2 pointA = points[i];
                Vector2 pointB = points[i + 1];
                Vector2 C = circle.position;// Center of circle
                // D = normal/direction of LineAB
                Vector2 D = (pointB - pointA).normalized;
                Vector2 perpendicular = new Vector2(-D.y, D.x);
                // t = distance from A to closest point on AB to C
                float t = D.x * (C.x - pointA.x) + D.y * (C.y - pointA.y);
                // E = closest point on AB to circle center
                Vector2 E = t * D + pointA;
                // EtoC = magnitude of Line EC, distance from line to center
                float EtoC = (circle.position - E).magnitude;
                //plane = EtoC < circle.radius;
                //alligned = (t > 0 && t < (pointB - pointA).magnitude);
                //hitting = alligned && plane;
                if (EtoC < circle.radius && (t > 0 && t < (pointB - pointA).magnitude))
                {
                    // End Line circle Collision
                    //e.EntityPosition = E + (perpendicular * circle.radius);
                    //compoundDisplacement += (perpendicular * (circle.radius - EtoC));
                    compoundDisplacement.Add(E + (perpendicular * circle.radius));
                    hit = true;
                    //Debug.Log("Touch! " + EtoC + "  " + perpendicular.x + "  " + C);
                }
            }
            if (closed)
            {
                Vector2 pointA = points[points.Length - 1];
                Vector2 pointB = points[0];
                //CircleCollider circle = e.hitbox;
                Vector2 C = circle.position;// Center of circle
                // D = normal/direction of LineAB
                Vector2 D = (pointB - pointA).normalized;
                Vector2 perpendicular = new Vector2(-D.y, D.x);
                // t = distance from A to closest point on AB to C
                float t = D.x * (C.x - pointA.x) + D.y * (C.y - pointA.y);
                // E = closest point on AB to circle center
                Vector2 E = t * D + pointA;
                // EtoC = magnitude of Line EC
                float EtoC = (circle.position - E).magnitude;
                //plane = EtoC < circle.radius;
                //alligned = (t > 0 && t < (pointB - pointA).magnitude);
                //hitting = alligned && plane;
                if (EtoC < circle.radius && (t > 0 && t < (pointB - pointA).magnitude))
                {
                    //e.EntityPosition = E + (perpendicular * (circle.radius));
                    //compoundDisplacement += (perpendicular * (circle.radius - EtoC));
                    compoundDisplacement.Add(E + (perpendicular * circle.radius));
                    hit = true;
                }
            }
            if (hit)
            {
                e.EntityPosition = Utility.Mean(compoundDisplacement);
            }
        }
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine((Vector3)points[i], (Vector3)points[i+1]);
            Gizmos.color = Color.red;
            Vector2 D = (points[i] - points[i + 1]).normalized;
            Vector2 perpendicular = new Vector2(-D.y, D.x);
            Gizmos.DrawLine((Vector3)points[i], (Vector3)points[i] + (Vector3)perpendicular);
            Gizmos.DrawLine((Vector3)points[i+1], (Vector3)points[i+1] + (Vector3)perpendicular);
        }
        if (closed)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine((Vector3)points[points.Length-1], (Vector3)points[0]);
            Gizmos.color = Color.red;
            Vector2 D = (points[points.Length - 1] - points[0]).normalized;
            Vector2 perpendicular = new Vector2(-D.y, D.x);
            Gizmos.DrawLine((Vector3)points[points.Length - 1], (Vector3)points[points.Length-1] + (Vector3)perpendicular);
            Gizmos.DrawLine((Vector3)points[0], (Vector3)points[0] + (Vector3)perpendicular);
        }
    }
    
}
