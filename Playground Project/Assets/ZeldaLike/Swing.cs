using UnityEngine;
using System.Collections;

public class Swing : MonoBehaviour {

    public float angleDeg = 0;
    public float angleRad
    {
        get
        {
            return angleDeg * Mathf.Deg2Rad;
        }
        set
        {
            angleDeg = value * Mathf.Rad2Deg;
        }
    }

    public Vector2 pivot;

    public float pivotDistance = 0.5f;

    public float speed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        Vector2 pos = pivot + (AngleToVector(angleRad) * pivotDistance);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        transform.localRotation = Quaternion.Euler(0, 0, -angleDeg);

        angleDeg += speed;

        if (angleDeg >= 360)
        {
            angleDeg -= 360;
        }
        if (angleDeg < 0)
        {
            angleDeg += 360;
        }
	}

    Vector2 AngleToVector(float _angleRad)
    {
        return new Vector2(Mathf.Sin(_angleRad), Mathf.Cos(_angleRad));
    }
}
