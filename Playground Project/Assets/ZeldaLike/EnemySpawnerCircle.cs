using UnityEngine;
using System.Collections;

public class EnemySpawnerCircle : MonoBehaviour
{

    [SerializeField]
    private Monster enemyToSpawn;

    public float radius = 5;
    public float timeDelay = 10;

    private float time = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;

        if (time >= timeDelay)
        {
            time -= timeDelay;

            Vector2 newVec = new Vector2(FreeRNG.FloatRange(-1, 1), FreeRNG.FloatRange(-1, 1));
            newVec.Normalize();

            Instantiate(enemyToSpawn, new Vector3(newVec.x * radius, newVec.y * radius, 0), enemyToSpawn.transform.localRotation);
        }
	}
}
