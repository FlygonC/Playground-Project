using UnityEngine;
using System.Collections;
using System.Linq;

public enum Direction { North = 0, East = 1, South = 2, West = 3 };

public enum Team { Neutral, Player, Enemy };

public class ActorB : Entity
{

    public Team alliance;

    public int healthMax = 4;
    public int health = 4;

    public Direction facing = Direction.North;

    public Vector2 pushForce = new Vector2();
    public Vector2 hardForce = new Vector2();
    
	protected virtual void FixedUpdate ()
    {
        EntityPosition += pushForce + hardForce;
        pushForce *= 0.5f;
        hardForce *= 0;
        if (pushForce.magnitude < 0.01)
        {
            pushForce *= 0;
        }

        foreach (ActorB i in FindObjectsOfType<ActorB>().Where(x => x != this))
        {
            if (hitbox.Collision(i.hitbox))
            {
                hardForce += (i.EntityPosition - EntityPosition) * (Utility.Distance(EntityPosition, i.EntityPosition) - ((size / 2) + (i.size / 2)));
            }
        }
	}

    public virtual void GetHit(ActorB source)
    {
        pushForce = (EntityPosition - source.EntityPosition).normalized * 0.5f;
    }
    public virtual void GetHit(Vector2 source)
    {
        pushForce = (EntityPosition - source).normalized * 0.5f;
    }
    public virtual void TakeDamage(int amount)
    {
        health -= amount;
    }
}
