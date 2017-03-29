using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineHitPoints : MonoBehaviour
{

    public int points = 5;
    public float length = 1;
    //public float angleDeg = 0;
    public float debugFloat = 0;

    public List<Vector2> vecs = new List<Vector2>();

    void Update()
    {
        debugFloat = transform.localRotation.ToEulerAngles().z;
        vecs.Clear();
        float slice = length / (points - 1);
        for (int i = 0; i < points; i++)
        {
            float dist = slice * i;
            Vector2 point = (Vector2)transform.position + (Utility.AngleToVector(-transform.localRotation.ToEulerAngles().z) * dist);
            vecs.Add(point);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Vector2 i in vecs)
        {
            Gizmos.DrawSphere((Vector3)i, 0.1f);
        }
        
    }
}
