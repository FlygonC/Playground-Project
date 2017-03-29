using UnityEngine;
using System.Collections;
using System.Linq;

public class Projectile : Entity
{

    public Team alliance;
    

    public float speed = 0.2f;
    public Vector2 direction = new Vector2();
    public float maxTravel = 50;
    private float distTraveled = 0;

    public int damage;

    
    void FixedUpdate ()
    {
	    if (distTraveled >= maxTravel)
        {
            Destroy(gameObject);
            return;
        }

        EntityPosition += direction.normalized * speed;
        distTraveled += speed;

        foreach (ActorB i in FindObjectsOfType<ActorB>().Where(x => x.alliance != alliance))
        {
            if (hitbox.Collision(i.hitbox))
            {
                HitActor(i);
                break;
            }
        }
	}

    protected virtual void HitActor(ActorB hit)
    {
        hit.GetHit(EntityPosition);
        hit.TakeDamage(damage);
        Destroy(gameObject);
    }
}
