using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleAlgorithm : MonoBehaviour {

    public int points = 8;
    public float radius = 1;
    public Vector2 center;

    public List<Vector2> vecs = new List<Vector2>();

	// Use this for initialization
	void Start () {
        DrawCirclePoints(points, radius, center);
	}

    [ContextMenu("Draw")]
    void DrawCirclePoints(int points, float radius, Vector2 center)
    {
        float slice = 2 * Mathf.PI / points;

        for (int i = 0; i < points; i++)
        {
            float angle = slice * i;
            float newX = center.x + radius * Mathf.Cos(angle);
            float newY = center.y + radius * Mathf.Sin(angle);
            Vector2 p = new Vector2(newX, newY);
            vecs.Add(p);
            Debug.Log(p);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int i = 0; i < vecs.Count - 1; i++)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine((Vector3)vecs[i], (Vector3)vecs[i + 1]);
        }
    }
}
