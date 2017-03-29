using UnityEngine;
using System.Collections;

public class mess : MonoBehaviour
{

    public float damage;
    public float armor;
    public float toughness;

    public float finalDamage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        finalDamage = damage * (1 - Mathf.Min(20, Mathf.Max(armor / 5, armor - damage / (2 + toughness / 4))) / 25);
	}
}
