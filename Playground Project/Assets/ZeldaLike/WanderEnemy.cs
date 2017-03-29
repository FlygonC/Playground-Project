using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Monster))]
public class WanderEnemy : MonoBehaviour
{
    private Monster thisMon;

    public float speed = 0.1f;
    public float offsetDist = 1;
    public float erraticness = 1;

    private Vector2 lastVec = new Vector2();

	// Use this for initialization
	void Start ()
    {
        thisMon = GetComponent<Monster>();
	}
	


	// Update is called once per frame
	void Update ()
    {
        //float x = FreeRNG.FloatRange(-1.0f, 1.0f);
        //float y = FreeRNG.FloatRange(-1.0f, 1.0f);
        Vector2 offsetVec = lastVec.normalized * offsetDist;

        Vector2 newVec = offsetVec + new Vector2(FreeRNG.FloatRange(-erraticness, erraticness), FreeRNG.FloatRange(-erraticness, erraticness));

        lastVec = newVec;
        thisMon.EntityPosition += newVec.normalized * speed;
        thisMon.facing = Utility.VectorToDirection(newVec);
    }
}
