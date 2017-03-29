using UnityEngine;
using System.Collections;

public class LineWallTest : MonoBehaviour
{

    public Vector2 pointA = new Vector2();
    public Vector2 pointB = new Vector2();

    public Vector2 perpendicular;

    CircleCollider circle;

    public Vector2 D;
    public float t;
    public Vector2 E;
    public float EtoC;

    public bool plane = false;
    public bool alligned = false;
    public bool hitting = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 norm = (pointB - pointA).normalized;
        perpendicular = new Vector2(-norm.y, norm.x);
        //circle = FindObjectOfType<PlayerActor>().hitbox;

        foreach (Entity i in FindObjectsOfType<Entity>())
        {
            circle = i.hitbox;
            Vector2 C = circle.position;// Center of circle

            if (circle.Collision(pointA))
            {
                i.EntityPosition = pointA + ((i.EntityPosition - pointA).normalized * circle.radius);
                //return;
            }
            if (circle.Collision(pointB))
            {
                i.EntityPosition = pointB + ((i.EntityPosition - pointB).normalized * circle.radius);
                //return;
            }

            // D = normal/direction of LineAB
            D = (pointB - pointA).normalized;
            // t = distance from A to closest point on AB to C
            t = D.x * (C.x - pointA.x) + D.y * (C.y - pointA.y);
            // E = closest point on AB to circle center
            E = t * D + pointA;
            // EtoC = magnitude of Line EC
            EtoC = (circle.position - E).magnitude;


            plane = EtoC < circle.radius;

            alligned = t > 0 && t < (pointB - pointA).magnitude;

            hitting = alligned && plane;
            if (hitting)
            {
                i.EntityPosition = E + (perpendicular * (circle.radius));
                Debug.Log("Touch! " + EtoC + "  " + perpendicular + "  " + C);
                //return;
            }
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine((Vector3)pointA, (Vector3)pointB);
    }
}
