using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SwingingSword : MonoBehaviour {

    public SwordProperties properties;

    public ActorB swinger;

    public float startingAngle;

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

    //public bool reverse = false;

    private float swing = 0;
    private bool finished = false;
    
    private List<ActorB> actorsToHit = new List<ActorB>();

    void Start ()
    {
        startingAngle = angleDeg;
        SetPositionAndRotation();
        actorsToHit = FindObjectsOfType<ActorB>().ToList();
        //Collide();

        swing = (properties.swingLength * properties.speed) / 60;

        transform.localScale = new Vector3(1, properties.length, 1);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (finished)
        {
            Destroy(this.gameObject);
        }
        //Vector2 pivot = swinger.EntityPosition;
        //float pivotDistance = swinger.size / 2;

        //float swing = (properties.swingLength * properties.speed) / 60;
        angleDeg += swing;
        if (angleDeg >= startingAngle + properties.swingLength)
        {
            angleDeg = startingAngle + properties.swingLength;
            finished = true;
        }
        SetPositionAndRotation();
        Collide();
        


    }

    void Collide()
    {
        List<ActorB> beenhit = new List<ActorB>();

        foreach (ActorB i in actorsToHit)
        {
            if (i != swinger)
            {
                
                if (i.hitbox.Collision(GetHitBox()))
                {
                    i.GetHit(swinger);
                    i.TakeDamage(properties.damage);
                    beenhit.Add(i);
                }
            }
        }
        foreach (ActorB i in beenhit)
        {
            actorsToHit.RemoveAt(actorsToHit.IndexOf(i));
        }
    }

    void SetPositionAndRotation()
    {
        Vector2 pivot = swinger.EntityPosition;
        float pivotDistance = swinger.size / 2;

        Vector2 pos = pivot + (AngleToVector(angleRad) * pivotDistance);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        transform.localRotation = Quaternion.Euler(0, 0, -angleDeg);
    }

    public List<Vector2> GetHitBox()
    {
        List<Vector2> returnPoints = new List<Vector2>();

        int points = Mathf.CeilToInt(properties.length * 10);

        float slice = properties.length / (points - 1);
        for (int i = 0; i < points; i++)
        {
            float dist = slice * i;
            Vector2 point = (Vector2)transform.position + (Utility.AngleToVector(angleRad) * dist);
            returnPoints.Add(point);
            // Intermediary
            Vector2 point2 = (Vector2)transform.position + (Utility.AngleToVector(angleRad - ((swing / 2) * Mathf.Deg2Rad)) * dist);
            returnPoints.Add(point2);
        }

        return returnPoints;
    }

    Vector2 AngleToVector(float _angleRad)
    {
        return new Vector2(Mathf.Sin(_angleRad), Mathf.Cos(_angleRad));
    }
}


[System.Serializable]
public class SwordProperties
{
    public float length;
    /// <summary>
    /// Full swings per second.
    /// </summary>
    public float speed;
    public float swingLength;
    public int damage;

    public SwordProperties(float _length, float _speed, float _swingLength, int _damage)
    {
        length = _length;
        speed = _speed;
        swingLength = _swingLength;
        damage = _damage;
    }
}